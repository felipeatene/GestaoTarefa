using GestaoTarefas.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace GestaoTarefas.Business
{
    public class Negocio
    {
        //Variaveis.
        public static GestaoTarefasEntities gestao; // Conexão com banco.
        public Usuario usuarioLogado { get; set; }
        public enum Status { Finalizada = 1, AFazer = 2};

        //Construtor.
        public Negocio()
        {
            gestao = new GestaoTarefasEntities();
        }

        #region Usuario
        public Usuario CriarUsuario(string usua, string senha)
        {
            //Verificar se ja existe o usuario.
            var usu = from usuario in gestao.Usuario
                      where usuario.usuario1 == usua
                      select usuario;

            if (usu.Count() == 0)
            {
                Usuario newUsu = new Usuario();
                newUsu.usuario1 = usua;
                newUsu.senha = senha;
                gestao.AddToUsuario(newUsu);
                gestao.SaveChanges();
                return usu.First();
            }

            return null;
        }

        public Usuario Logar(string usua, string senha)
        {
            //Verificar se ja existe o usuario.
            var usu = from usuario in gestao.Usuario
                      where usuario.usuario1 == usua && usuario.senha == senha
                      select usuario;

            if (usu.Count() != 0)
            {
                usuarioLogado = usu.First();
                return usu.First();
            }
            return null;
        }
        #endregion

        #region Tarefa
        public Tarefa CriarTarefa(string descricaoTarefa)
        {
            Tarefa newTarefa = new Tarefa();

            newTarefa.Descricao = descricaoTarefa;
            newTarefa.Data = DateTime.Now;
            newTarefa.Usuario = usuarioLogado;
            newTarefa.Status = gestao.Status.First(p => p.ID == 1);

            gestao.AddToTarefa(newTarefa);
            gestao.SaveChanges();
            return newTarefa;
        }

        public Tarefa EditarTarefa(String novaDescricao, int idTarefa)
        {
            Tarefa tarefa = gestao.Tarefa.First(t => t.ID == idTarefa);

            tarefa.Descricao = novaDescricao;
            gestao.SaveChanges();
            return tarefa;
        }

        public Tarefa ConcluirTarefa(int idTarefa)
        {
            Tarefa tarefa = gestao.Tarefa.First(t => t.ID == idTarefa);

            tarefa.Status = gestao.Status.First(p => p.ID == 2);
            gestao.SaveChanges();
            return tarefa;
        }

        public Tarefa ExcluirTarefa(int idTarefa)
        {
            Tarefa tarefa = gestao.Tarefa.First(t => t.ID == idTarefa);

            tarefa.Status = gestao.Status.First(p => p.ID == 3);
            gestao.SaveChanges();
            return tarefa;
        }

        public IEnumerable<Tarefa> GetTarefasUsuarioAFazer()
        {
            IEnumerable<Tarefa> tarefas = from t in gestao.Tarefa
                                          where t.Usuario.ID == usuarioLogado.ID && t.Status.ID == 1
                                          select t;
            return tarefas;
        }
        public IEnumerable<Tarefa> GetTarefasUsuarioConcluir()
        {
            IEnumerable<Tarefa> tarefas = from t in gestao.Tarefa
                                          where t.Usuario.ID == usuarioLogado.ID && t.Status.ID == 2
                                          select t;
            return tarefas;
        }
        #endregion


    }
}

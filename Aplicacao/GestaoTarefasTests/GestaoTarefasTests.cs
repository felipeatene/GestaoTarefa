using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GestaoTarefas.Business;
using GestaoTarefas.Model;
using System.Collections.Generic;

namespace GestaoTarefasTests
{
    [TestClass]
    public class GestaoTarefasTests
    {
        Negocio servico;

        //Construtor.
        public GestaoTarefasTests()
        {
            servico = new Negocio();
        }

        [TestMethod]
        public void CriarUsuarioTest()
        {
            string usuario = "teste1";
            string senha = "senha1";

            Usuario usu = servico.CriarUsuario(usuario, senha);
            Assert.AreEqual(usuario, usu.usuario1);
            Assert.AreEqual(senha, usu.senha);
        }
        
        [TestMethod]
        public void LogarTest()
        {
            string usuario = "felipe";
            string senha = "123";

            Usuario usu = servico.Logar(usuario, senha);
            Assert.AreEqual(usuario, usu.usuario1);
            Assert.AreEqual(senha, usu.senha);
        }
        [TestMethod]
        public void CriarTarefaTest()
        {
            servico.usuarioLogado = new Usuario();
            servico.usuarioLogado.ID = 1;
            servico.usuarioLogado.usuario1 = "felipe";
            servico.usuarioLogado.senha = "123";
            string descricao = "Descricao teste";

            Tarefa tarefa = servico.CriarTarefa(descricao);

            Assert.AreEqual(descricao, tarefa.Descricao);
            Assert.AreEqual(servico.usuarioLogado.ID, tarefa.Usuario.ID);
        }

        [TestMethod]
        public void EditarTarefaTest()
        {
            string descricaoNova = "Descricao teste 2";
            int IDUsiario = 9;
            Tarefa tarefa = servico.EditarTarefa(descricaoNova, IDUsiario);
            Assert.AreEqual(descricaoNova, tarefa.Descricao);
        }
        [TestMethod]
        public void ConcluirTarefaTest()
        {
            int IDTarefa = 9;
            int IDStatus = 2;
            Tarefa tarefa = servico.ConcluirTarefa(IDTarefa);
            Assert.AreEqual(IDStatus, tarefa.Status.ID);
        }
        [TestMethod]
        public void ExcluirTarefaTest()
        {
            int IDTarefa = 9;
            int IDStatus = 3;
            Tarefa tarefa = servico.ExcluirTarefa(IDTarefa);
            Assert.AreEqual(IDStatus, tarefa.Status.ID);
        }
        [TestMethod]
        public void GetTarefasUsuarioAFazerTest()
        {
            IEnumerable<Tarefa> tarefas = servico.GetTarefasUsuarioAFazer();
            Assert.IsNotNull(tarefas);
        }
        [TestMethod]
        public void GetTarefasUsuarioConcluirTest()
        {
            IEnumerable<Tarefa> tarefas = servico.GetTarefasUsuarioConcluir();
            Assert.IsNotNull(tarefas);
        }

        
    }
}

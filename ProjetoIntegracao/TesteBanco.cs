using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using AvaCarona.API.Repositorios;
using AvaCarona.API.Domain;
using AvaCarona.API.Bussiness;

namespace ProjetoIntegracao
{
    [TestClass]
    public class TesteBanco
    {
        [TestMethod]
        public void AddColaboradorTest()
        {
            using (var context = new AvaCarona.API.Repositorios.AppContext())
            {
                var colaborador = new Colaborador() { EID = "t.de.matos" };    
                 
                var repositorio = new ColaboradorRepositoryEF(context);
                var business = new ColaboradorBusiness(repositorio);

                business.CadastrarColaborador(colaborador);
            }
        }
        [TestMethod]
        [ExpectedException(typeof(JaExisteColaboradorComEsseEIDException))]
        public void NaoPermitirColaboradorComMesmoEIDTest()
        {
            using (var context = new AvaCarona.API.Repositorios.AppContext())
            {
                var colaborador = new Colaborador() { EID = "t.de.matos" };

                var repositorio = new ColaboradorRepositoryEF(context);
                var business = new ColaboradorBusiness(repositorio);

                business.CadastrarColaborador(colaborador);
            }
        }

        [TestMethod]
        public void RemoveColaboradorTest()
        {
            using (var context = new AvaCarona.API.Repositorios.AppContext())
            {
                var colaborador = new Colaborador() { EID = "t.de.matos" };

                var repositorio = new ColaboradorRepositoryEF(context);
                var business = new ColaboradorBusiness(repositorio);

                business.RemoverColaborador(colaborador);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ColaboradorNaoExisteException))]
        public void RemoveColaboradorQueNaoExisteTest()
        {
            using (var context = new AvaCarona.API.Repositorios.AppContext())
            {
                var colaborador = new Colaborador() { EID = "t.de.matos" };

                var repositorio = new ColaboradorRepositoryEF(context);
                var business = new ColaboradorBusiness(repositorio);

                business.RemoverColaborador(colaborador);
            }
        }

    }
}

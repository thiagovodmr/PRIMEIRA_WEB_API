using AvaCarona.API.Bussiness;
using AvaCarona.API.Domain;
using AvaCarona.API.Repositorios;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace AvaCarona.UniTests
{
    [TestClass]
    public class ColaboradorBusinessTests
    {
        [TestMethod]
        [ExpectedException(typeof(JaExisteColaboradorComEsseEIDException))]
        public void NaoPermitirColaboradorComEsteEIDException()
        {
            var repositorio = new ColaboradoresRepositoryIM();
            repositorio.Add(new Colaborador() { EID = "t.de.matos" });

            var business = new ColaboradorBusiness(repositorio);
            var colabNovo = new Colaborador() { EID = "t.de.matos"};

            business.CadastrarColaborador(colabNovo);
        }

        [TestMethod]
        public void ListarColaboradoresTest()
        {
            var repositorio = new ColaboradoresRepositoryIM();
            var business = new ColaboradorBusiness(repositorio);

            var lista = business.List();
            Assert.AreEqual(0, repositorio.Count);
        }

    }
}

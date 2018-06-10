using AvaCarona.API.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace AvaCarona.UniTests
{
    [TestClass]
    public class CaronaTest
    {
        //[TestMethod]
        //public void OcuparVaga_VagasInsufucientesTests()
        //{
        //    //preparacao
        //    var carona = new Carona(0, new Colaborador() );
        //    //execucao
        //    carona.OcupeVaga(new Colaborador() );
            
        //}

        //[TestMethod]
        //public void OcuparVaga_VagasSuficientesTests()
        //{
        //    //preparacao
        //    var carona = new Carona(1, new Colaborador() );
        //    carona.OcupeVaga(new Colaborador() );

            
        //}

        [TestMethod]
        [ExpectedException(typeof(LimiteDeVagasExcedidoException))]
        public void LimiteDeVagasExcedidoTest()
        {
            //preparacao
            var carona = Carona.CreateCarona(9, new Colaborador());

        }

        [TestMethod]
        [ExpectedException(typeof(CaronaSemOfertanteException))]
        public void CriarCaronaSemOfertanteTest()
        {
            //preparacao
            var carona = Carona.CreateCarona(0, null);

        }
    }
}

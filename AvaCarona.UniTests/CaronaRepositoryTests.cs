using Microsoft.VisualStudio.TestTools.UnitTesting;
using AvaCarona.API;
using System;
using System.Collections.Generic;
using System.Text;
using AvaCarona.API.Repositorios;
using AvaCarona.API.Domain;

namespace AvaCarona.UniTests
{
    [TestClass]
    public class CaronaRepositoryTests
    {
        [TestMethod]
        public void AddCarona_VerificandoId()
        {
            var repository = new CaronasRepositoryIM();
            var carona = Carona.CreateCarona(1, new Colaborador());
            var caronaGuardada = repository.Add(carona);

            int idEsperado = 1;
            int actual = caronaGuardada.Id;

            Assert.AreEqual(idEsperado, actual);

        }

        [TestMethod]
        public void RemoveCarona_VerificarId()
        {
            var repository = new CaronasRepositoryIM();

            var carona = Carona.CreateCarona(1,new Colaborador() );
            repository.Add(carona);
            var caronaParaRemover = repository.Add(carona);
            repository.Add(carona);

            var caronaDeletada = repository.Delete(caronaParaRemover);

            Assert.AreEqual(caronaParaRemover.Id, caronaDeletada.Id);
        }


    }
}

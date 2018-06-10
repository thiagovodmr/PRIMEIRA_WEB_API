using AvaCarona.API.Domain;
using AvaCarona.API.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AvaCarona.API.Bussiness
{
    public class CaronaBusiness
    {
        private IRepository<Carona> repositorio;

        public CaronaBusiness(IRepository<Carona> repository)
        {
            repositorio = repository;
        }

        public void CadastrarCarona(Carona carona)
        {
            if (carona != null) throw new ArgumentNullException();
            repositorio.Add(carona);
        }

        public Carona GetById(int id)
        {
            return repositorio.GetById(id);
        }

        public void RemoverCarona(Carona carona)
        {
            if (carona == null) throw new ArgumentNullException();
            if (!ExisteCarona(carona)) throw new ColaboradorNaoExisteException();
            var colaboradorDelete = repositorio.GetById(carona.Id);
            repositorio.Delete(colaboradorDelete);
        }

        public List<Carona> List()
        {
            return repositorio.ListarRepository().ToList();
        }

        private bool ExisteCarona(Carona carona)
        {
            return repositorio.GetById(carona.Id) != null;
        }
    }
}

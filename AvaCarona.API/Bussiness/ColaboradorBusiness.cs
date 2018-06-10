using AvaCarona.API.Domain;
using AvaCarona.API.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AvaCarona.API.Bussiness
{
    public class ColaboradorBusiness
    {
        private IColaboradorRepositorio _repositorio;

        public ColaboradorBusiness(IColaboradorRepositorio repository)
        {
            _repositorio = repository;
        }

        public void CadastrarColaborador(Colaborador colaborador)
        {   
            if (ExisteColaborador(colaborador)) throw new JaExisteColaboradorComEsseEIDException();
            
            _repositorio.Add(colaborador);
            
        }

        public void RemoverColaborador(Colaborador colaborador)
        {
            if (colaborador == null) throw new ArgumentNullException();
            if (!ExisteColaborador(colaborador)) throw new ColaboradorNaoExisteException();
            var colaboradorDelete = _repositorio.GetById(colaborador.Id);
            _repositorio.Delete(colaboradorDelete);

        }



        private bool ExisteColaborador(Colaborador colaborador)
        {
            var result = _repositorio.Get(c => c.Equals(colaborador)) != null;
            return result;
        }


        public List<Colaborador> List()
        {
            return _repositorio.ListarRepository().ToList();
        }

       public Colaborador GetById(int id)
        {
            return _repositorio.GetById(id);
        }
    }
}

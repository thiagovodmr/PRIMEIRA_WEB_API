using AvaCarona.API.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace AvaCarona.API.Repositorios
{
    public class ColaboradorRepositoryEF : ARepositoryEF<Colaborador>, IColaboradorRepositorio
    {
        public ColaboradorRepositoryEF(AppContext context) : base(context)
        {
        }
    }
}

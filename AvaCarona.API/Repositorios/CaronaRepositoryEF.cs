using AvaCarona.API.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace AvaCarona.API.Repositorios
{
    public class CaronaRepositoryEF : ARepositoryEF<Carona>, ICaronaRepository
    {
        public CaronaRepositoryEF(AppContext context) : base(context)
        {
        }
    }
}

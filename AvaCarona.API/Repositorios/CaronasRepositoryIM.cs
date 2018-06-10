using AvaCarona.API.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace AvaCarona.API.Repositorios
{
    public class CaronasRepositoryIM : ARepositoryIM<Carona>
    {
        public IEnumerable<Carona> ListarCaronasPorColaborador(Colaborador colaborador)
        {
            var caronas = List(c => c.Ofertante.EID == colaborador.EID);
            return caronas;
        }
    }
}

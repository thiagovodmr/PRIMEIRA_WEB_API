using AvaCarona.API.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AvaCarona.API.Repositorios
{
    public class CaronaColaborador
    {
       
        public int CaronaId { get; set; }
   
        public int ColaboradorId { get; set; }

        public Carona Carona { get; set; }
        public Colaborador Colaborador { get; set; }
    }
}

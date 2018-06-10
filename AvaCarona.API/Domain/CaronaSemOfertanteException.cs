using System;
using System.Collections.Generic;
using System.Text;

namespace AvaCarona.API.Domain
{
    public class CaronaSemOfertanteException : Exception
    {
        public override string Message => "Você não identificou quem é o ofertante da vaga";
    }
}

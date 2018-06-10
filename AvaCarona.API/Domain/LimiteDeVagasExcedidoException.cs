using System;
using System.Collections.Generic;
using System.Text;

namespace AvaCarona.API.Domain
{
    public class LimiteDeVagasExcedidoException : Exception
    {
        public override string Message => "O limite de vagas é 6, você tentou criar uma carona com um número maior de vagas";
    }
}

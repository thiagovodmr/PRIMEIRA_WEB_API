using System;

namespace AvaCarona.API.Domain
{
    public  class VagasInsufucientesException : Exception
    {
        public override string Message => "Vagas insuficientes";
    }
}
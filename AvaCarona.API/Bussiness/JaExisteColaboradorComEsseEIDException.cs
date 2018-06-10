using System;

namespace AvaCarona.API.Bussiness
{
    public class JaExisteColaboradorComEsseEIDException : Exception
    {
        public override string Message => "já existe Colaborador com Esse EID";
    }
}
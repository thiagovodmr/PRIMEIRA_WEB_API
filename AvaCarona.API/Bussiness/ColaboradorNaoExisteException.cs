using System;

namespace AvaCarona.API.Bussiness
{
    public class ColaboradorNaoExisteException : Exception
    {
        public override string Message => "Colaborador que você tentou remover não existe";
    }
}
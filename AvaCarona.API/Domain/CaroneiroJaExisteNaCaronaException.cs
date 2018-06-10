using System;

namespace AvaCarona.API.Domain
{
    public  class CaroneiroJaExisteNaCaronaException : Exception
    {
        public override string Message => "Caroneiro já existe na carona";
    }
}
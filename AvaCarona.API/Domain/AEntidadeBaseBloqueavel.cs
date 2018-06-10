using System;
using System.Collections.Generic;
using System.Text;

namespace AvaCarona.API.Domain
{
    public abstract class AEntidadeBaseBloqueavel : AEntidadeBase
    {
        public bool Bloqueado { get; set; }

        public void Bloquear()
        {
            Bloqueado = true;
        }
        public void Desbloquear()
        {
            Bloqueado = false;
        }
        public bool IsBloqueado()
        {
            return Bloqueado;
        }
    }
}

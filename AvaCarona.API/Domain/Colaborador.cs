using AvaCarona.API.Bussiness;
using System;
using System.Collections.Generic;
using System.Text;

namespace AvaCarona.API.Domain
{
    public class Colaborador : AEntidadeBaseBloqueavel
    {
        public string Nome { get; set; }
        public string EID { get; set; }
        public int PID { get; set; }

        public bool Equals(Colaborador colaborador)
        {
            if (!(colaborador is Colaborador)) throw new ColaboradorJaCadastradoException();
            if (colaborador.Id == Id) return true;
            if (colaborador.EID == EID) return true;
            if (colaborador.PID == PID) return true;

            return false;

        }

    }
}

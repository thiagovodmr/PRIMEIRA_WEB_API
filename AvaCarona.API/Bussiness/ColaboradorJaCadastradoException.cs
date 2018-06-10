using System;

namespace AvaCarona.API.Bussiness
{
    public class ColaboradorJaCadastradoException : Exception
    {
        public override string Message => "esse Colaborador já está cadastrado no sistema";


    }
}
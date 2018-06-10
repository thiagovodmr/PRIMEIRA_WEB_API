using AvaCarona.API.Repositorios;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace AvaCarona.API.Domain
{
    public class Carona : AEntidadeBaseBloqueavel
    {
        private const int limite_vagas = 6;
   
        public Colaborador Ofertante { get; set; }
        public string DaraHoraSaida { get; set; }
        public Endereco EnderecoSaida { get; set; }
        public Endereco EnderecoChegada { get; set; }
        public int VagasTotais { get; set; }
        public int VagasOcupadas { get; set; }
        public ICollection<CaronaColaborador> Passageiros { get; set; } = new List<CaronaColaborador>();
       

        public int VagasDisponiveis{
            get {
                return VagasTotais - Passageiros.Count;
            }
     
        }
        
        public void OcupeVaga(Colaborador caroneiro)
        {
            if (caroneiro == null) throw new ArgumentNullException("Passageiros");
            if (VagasDisponiveis <= 0) throw new VagasInsufucientesException();
            if (JaExisteCaroneiroNaCarona(caroneiro)) throw new CaroneiroJaExisteNaCaronaException();

            Passageiros.Add(new CaronaColaborador()
            {
                CaronaId = this.Id,
                ColaboradorId = caroneiro.Id,
                Carona = this,
                Colaborador = caroneiro

            });
        }

        private bool JaExisteCaroneiroNaCarona(Colaborador colaborador)
        {
            return Passageiros.Any(cc => cc.ColaboradorId == colaborador.Id);
        }

        //public bool DesocupeVaga(Colaborador colaborador)
        //{
        //    if (VagasOcupadas > 0)
        //    {
        //        VagasOcupadas = VagasOcupadas - 1;
        //        Passageiros.Remove(colaborador);
        //        return true;
        //    }
        //    return false;

        //}

        public static Carona CreateCarona(int vagas, Colaborador Ofertante)
        {
            if (vagas > limite_vagas)
            {
                throw new LimiteDeVagasExcedidoException();
            }

            if (Ofertante == null)
            {
                throw new CaronaSemOfertanteException();
            }

            return new Carona(vagas, Ofertante);
        }

        //contrutores
        public Carona() : base()
        {

        }
        public Carona(int vagas, Colaborador ofertante) : base()
        {
            VagasTotais = vagas;
            Ofertante = ofertante;
        }
    }
}

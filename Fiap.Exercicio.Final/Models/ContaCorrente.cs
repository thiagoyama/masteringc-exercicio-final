using Fiap.Exercicio.Final.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fiap.Exercicio.Final.Models
{
    class ContaCorrente : Conta
    {
        public TipoConta Tipo { get; set; }
        public decimal Limite { get; set; }

        public ContaCorrente(int agencia, int numero, IList<Cliente> clientes, TipoConta tipo) : base (agencia, numero, clientes)
        {
            Tipo = tipo;
            ConfigurarLimite();
        }
        
        private void ConfigurarLimite()
        {
            Limite = Tipo == TipoConta.Especial ? 500 : Tipo == TipoConta.Premium ? 1000 : 0;
            //if (Tipo == TipoConta.Especial)
            //    Limite = 500;
            //else if (Tipo == TipoConta.Premium)
            //    Limite = 1000;
        }

        public override void Retirar(decimal valor)
        {
           if (valor > Saldo + Limite)
           {
                throw new SaldoInsuficienteException("Saldo insuficiente");
           }
           Saldo -= valor;
        }

        public override string ToString()
        {
            return base.ToString() + $", tipo conta: {Tipo}, limite: {Limite.ToString("c")}";
        }
    }
}

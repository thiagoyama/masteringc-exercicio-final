using Fiap.Exercicio.Final.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fiap.Exercicio.Final.Models
{
    class ContaPoupanca : Conta, IContaInvestimento
    {
        public decimal Taxa { get; set; }

        public ContaPoupanca(int agencia, int numero, IList<Cliente> clientes, decimal taxa) : base(agencia, numero, clientes)
        {
            Taxa = taxa;
        }

        public decimal CalcularRetornoInvestimento()
        {
            return Saldo * 0.04m;
        }

        public override void Retirar(decimal valor)
        {
            if (valor + Taxa > Saldo)
                throw new SaldoInsuficienteException("Saldo insuficiente");
            Saldo -= valor + Taxa;
        }

        public override string ToString()
        {
            return base.ToString() + $", taxa: {Taxa}";
        }
    }
}

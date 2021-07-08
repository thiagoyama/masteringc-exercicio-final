using System;
using System.Collections.Generic;
using System.Text;

namespace Fiap.Exercicio.Final.Models
{
    abstract class Conta
    {
        public int Agencia { get; set; }
        public int Numero { get; set; }
        public decimal Saldo { get; protected set; }
        public DateTime DataAbertura { get; set; }
        public IList<Cliente> Clientes { get; set; }

        public Conta(int agencia, int numero, IList<Cliente> clientes)
        {
            Agencia = agencia;
            Numero = numero;
            Clientes = clientes;
        }

        public virtual void Depositar(decimal valor)
        {
            Saldo += valor;
        }

        public abstract void Retirar(decimal valor);

        public override string ToString()
        {
            var detalhes = "";
            //Percorre a lista de clientes para exibi-los nos detalhes da conta
            foreach (var item in Clientes)
            {
                detalhes += $"{item} \n";
            }
            detalhes += $"Agencia: {Agencia}, número: {Numero}, Saldo: {Saldo.ToString("c")}, Data Abertura: {DataAbertura}";
            return detalhes;
        }
    }
}

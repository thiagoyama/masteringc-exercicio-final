using System;
using System.Collections.Generic;
using System.Text;

namespace Fiap.Exercicio.Final.Models
{
    class Cliente
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }

        public Cliente(long id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public override string ToString()
        {
            return $"Id: {Id}, nome: {Nome}, cpf: {Cpf}";
        }
    }
}

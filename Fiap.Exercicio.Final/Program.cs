using Fiap.Exercicio.Final.Exceptions;
using Fiap.Exercicio.Final.Models;
using System;
using System.Collections.Generic;

namespace Fiap.Exercicio.Final
{
    class Program
    {
        static void Main(string[] args)
        {
            //Criar uma lista de cliente 
            var clientes = new List<Cliente>();
            
            Console.WriteLine("Digite a quantidade de clientes");
            var qtd = int.Parse(Console.ReadLine());

            for (int i = 1; i <= qtd; i++)
            {

                //Ler os dados do cliente
                Console.WriteLine($"Digite o Id do cliente {i}");
                long id = long.Parse(Console.ReadLine());

                Console.WriteLine($"Digite o nome do cliente {i}");
                string nome = Console.ReadLine();

                Console.WriteLine($"Digite o cpf do cliente {i}");
                string cpf = Console.ReadLine();

                //Instanciar o cliente
                Cliente cliente = new Cliente(id, nome) { Cpf = cpf };

                //Adicionar o cliente na lista
                clientes.Add(cliente);
            }

            //Ler os dados da conta corrente
            Console.WriteLine("Digite o número da conta corrente");
            var numero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o número da agencia da conta corrente");
            var agencia = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a data de abertura da conta corrente");
            var dataAbertura = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Digite o tipo da conta");
            // variavel = (cast) Converte a String para dos valores do Enum TipoConta , true -> não diferencia maiusculas de minusculas
            TipoConta tipo = (TipoConta) Enum.Parse(typeof(TipoConta), Console.ReadLine(), true);
                        
            //Instanciar a conta corrente
            ContaCorrente cc = new ContaCorrente(agencia: agencia, numero: numero, clientes: clientes, tipo: tipo) { DataAbertura = dataAbertura };

            //Exibir os dados da conta corrente
            Console.WriteLine($"Conta Corrente: \n{cc}");

            //Ler os dados da conta poupança
            Console.WriteLine("Digite o número da conta poupança");
            numero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o número da agencia da conta poupança");
            agencia = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a data de abertura da conta poupança");
            dataAbertura = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Digite a taxa de retirada da conta poupança");
            var taxa = decimal.Parse(Console.ReadLine());

            //Instanciar a conta poupança
            var poupanca = new ContaPoupanca(agencia: agencia, numero: numero, clientes: clientes, taxa: taxa) { DataAbertura = dataAbertura }; 

            //Exibir os dados da conta poupança
            Console.WriteLine($"Conta poupança: \n{poupanca}");

            int opcao;

            do
            {
                Console.WriteLine("\n*****************************\n" +
                    "Escoha uma das opções: \n1-Depositar Conta Corrente \n2-Retirar Conta Corrente \n3-Depositar Conta Poupança " +
                    "\n4-Retirar Conta Poupança \n5-Exibir dados das contas \n6-Calcular Retorno Investimento \n0-Sair" +
                    "\n*****************************\n");

                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:                        
                        Console.WriteLine("Digite o valor de depósito");
                        cc.Depositar(decimal.Parse(Console.ReadLine()));
                        Console.WriteLine($"Novo saldo: {cc.Saldo}");
                        break;
                    case 2:
                        try
                        {
                            Console.WriteLine("Digite o valor para retirada");
                            cc.Retirar(decimal.Parse(Console.ReadLine()));
                            Console.WriteLine($"Novo saldo: {cc.Saldo}");
                        } catch (SaldoInsuficienteException e)
                        {
                            Console.WriteLine($"Não foi possível realizar a retirada: {e.Message}");
                        }
                        break;
                    case 3:
                        Console.WriteLine("Digite o valor de depósito");
                        poupanca.Depositar(decimal.Parse(Console.ReadLine()));
                        Console.WriteLine($"Novo saldo: {poupanca.Saldo}");
                        break;
                    case 4:
                        try
                        {
                            Console.WriteLine("Digite o valor para retirada");
                            poupanca.Retirar(decimal.Parse(Console.ReadLine()));
                            Console.WriteLine($"Novo saldo: {poupanca.Saldo}");
                        }
                        catch (SaldoInsuficienteException e)
                        {
                            Console.WriteLine($"Não foi possível realizar a retirada: {e.Message}");
                        }
                        break;
                    case 5:
                        Console.WriteLine($"Conta corrente: \n{cc}");
                        Console.WriteLine($"Conta poupança: \n{poupanca}");
                        break;
                    case 6:
                        Console.WriteLine($"O retorno do investimento é : {poupanca.CalcularRetornoInvestimento()}");
                        break;
                    case 0:
                        Console.WriteLine("Finalizando o sistema");
                        break;
                    default:
                        Console.WriteLine("Opção inválida");
                        break;
                }


            } while (opcao != 0);

        }
    }
}

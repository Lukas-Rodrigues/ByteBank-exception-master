using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank
{
    class Program
    {
        static void Main(string[] args)
        {
            //ContaCorrente conta = new ContaCorrente(8748, 9815874);
            //Console.WriteLine(ContaCorrente.TaxaOperacao);
            try
            {
                ContaCorrente conta = new ContaCorrente(0, 25);
            }
                    //ArgumentException serve para verificar se os argumentos 
            catch (ArgumentException ex)
            {
                Console.WriteLine("Erro no parâmetro: " + ex.ParamName);
                Console.WriteLine("Ocorreu um erro do tipo ArgumentException.");
                Console.WriteLine(ex.Message);
                //StackTrace - esponsável por obter uma representação de cadeias de caracteres d
                //e quadros imediatos na nossa pilha de chamadas. ajudar
                Console.WriteLine(ex.StackTrace);
                Console.WriteLine(ex.StackTrace);

                Console.WriteLine("Informações da INNER EXCEPTION (exceção interna):");
                //InnerException - Vai mostrar o saldo apenas para o desenvolvedor. Isso deixa mais seguro as informações do cliente.
                Console.WriteLine(ex.InnerException.Message);
                Console.WriteLine(ex.InnerException.StackTrace);
            }
            catch (SaldoInsuficienteExceptions ex)
            {
                Console.WriteLine("Saldo Insuficiente");
                
            }


            Console.ReadLine();
        }
        private static void Metodo()
        {
            try
            {
                TestaDivisao(2);
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Ocorreu um erro! Não é possível dividir um número por 0!");
            }
            //quando instanciar um objeto quando o valor é nulo
            catch (NullReferenceException)
            {
                Console.WriteLine("Ocorreu um erro!");
            }
        }

        private static void TestaDivisao(int divisor)
        {
            int resultado = Dividir(10, divisor);

            Console.WriteLine("Resultado da divisão de 10 por" + divisor + " é " + resultado);
        }

        private static int Dividir(int numero, int divisor)
        {
            try
            {
                return numero / divisor;
            }
            catch (Exception)
            {

                Console.WriteLine("Excessão com número = " + numero  + " e divior = " + divisor);
                throw;
            }
           
        }
    }
}

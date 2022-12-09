 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank
{
    public class ContaCorrente
    {
        public Cliente Titular { get; set; }
        public static double TaxaOperacao { get; private set; } 
        public static int TotalDeContasCriadas { get; private set; }
        public int ContadorSaquesNaoPermitidos { get; private set; }
        public int ContadorTransferenciasNaoPermitidas { get; private set; }

        private int _agencia;
        public int Agencia
        {
            get
            {
                return _agencia;
            }
            private set
            {
                if (value <= 0)
                {
                    return;
                }

                _agencia = value;
            }
        }
        //readonly - deixar a propriedade somente leitura, isso fará que nosso código fique com menos erros e mais seguros
        public int Numero { get; }

        private double _saldo = 100;

        public double Saldo
        {
            get
            {
                return _saldo;
            }
            set
            {
                if (value < 0)
                {
                    return;
                }

                _saldo = value;
            }
        }


        public ContaCorrente(int agencia, int numero)
        {
            Agencia = agencia;
            Numero = numero;
            //TaxaOperacao = 30 / TotalDeContasCriadas;
            TotalDeContasCriadas++;
            if (numero <= 0 && agencia <= 0)
            {
                throw new ArgumentException("Os argumentos numeros e agência devem ser maiores qeu zero.");
            }
            if (agencia <= 0)
            {
                throw new ArgumentException("O argumento agencia deve ser maior que 0.", nameof(agencia));
            }
            if (numero <= 0)
            {
                throw new ArgumentException("O argumento numero deve ser maior que 0.", nameof(numero));
            }
          

        }


        public void Sacar(double valor)
        {
            if (_saldo < valor)
            {
                ContadorSaquesNaoPermitidos++;
                throw new SaldoInsuficienteExceptions($"Saldo insuficiente no valor de: {valor:C} ");
            }

            _saldo -= valor;
           
        }

        public void Depositar(double valor)
        {
            _saldo += valor;
        }


        public bool Transferir(double valor, ContaCorrente contaDestino)
        {
            try
            {
                Sacar(valor);
            }
            catch (SaldoInsuficienteExceptions ex)
            {
                ContadorTransferenciasNaoPermitidas++;
                throw new OperacaoFinanceiraExceptions("Operação não realizada.", ex);
            }

            _saldo -= valor;
            contaDestino.Depositar(valor);
            return true;
        }
    }
    }
}

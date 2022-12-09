using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank
{
    public class SaldoInsuficienteExceptions: OperacaoFinanceiraExceptions
    {
        public SaldoInsuficienteExceptions(string mensagem) : base(mensagem) 
        {

        }

    }
}

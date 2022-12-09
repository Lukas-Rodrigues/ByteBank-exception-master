using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank
{
    public class OperacaoFinanceiraExceptions: Exception
    {
        public OperacaoFinanceiraExceptions()
        {

        }
        public OperacaoFinanceiraExceptions(string mensagem) : base(mensagem)
        {
            
        }
        public OperacaoFinanceiraExceptions(string mensagem, Exception excecaoInterna) : base(mensagem,excecaoInterna)
        {

        }

    }
}

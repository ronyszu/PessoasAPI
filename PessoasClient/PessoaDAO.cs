using System;
using System.Collections.Generic;
using System.Text;

namespace PessoasClient
{
    class PessoaDAO
    {

        public string Nome { get; set; }

        public string Cpf { get; set; }

        public string Data_nascimento { get; set; }

        public EnderecoDAO Endereco { get; set; }

        


    }
}

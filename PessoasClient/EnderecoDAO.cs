using System;
using System.Collections.Generic;
using System.Text;

namespace PessoasClient
{
    class EnderecoDAO
    {

        public string Cep { get; set; }


        public string Logradouro { get; set; }

        public int Numero { get; set; }

        public string Complemento { get; set; }


        public PaisDAO Pais { get; set; }

        public EstadoDAO Estado { get; set; }

        public CidadeDAO Cidade { get; set; }





    }
}

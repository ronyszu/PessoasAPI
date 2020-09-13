using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PessoasAPI.Classes
{
    public class Endereco
    {

        public int Id { get; set; }
        public string Cep { get; set; }

        public string Logradouro { get; set; }

        public string Complemento { get; set; }

        public int Numero { get; set; }


        public int Cidade_fk { get; set; }


        public int Pais_fk { get; set; }


        public int Estado_fk { get; set; }



    }
}

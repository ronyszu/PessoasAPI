using PessoasAPI.Classes;
using System;

namespace PessoasAPI
{
    public class Pessoa
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public string Cpf { get; set; }

        public string Data_nascimento { get; set; }

        public Endereco Endereco { get; set; }
    }
}

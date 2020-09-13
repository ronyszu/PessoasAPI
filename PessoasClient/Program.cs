using PessoasAPI;
using PessoasAPI.Controllers;
using System;
using System.IO;
using System.Net;
using System.Text;

namespace PessoasClient
{
    class Program
    {
        static void Main(string[] args)
        {


 
                // Pedir o CPF da pessoa
                Console.Write("Insira o CPF da pessoa desejada: ");
                var cpfValue = Console.ReadLine();


            //roda API

            //PessoasAPI.Program.Main(new string[0]);

            PessoaController pc = new PessoaController();

            Pessoa details = pc.GetPessoa(cpfValue);

            //chamada para a API

            //string url = string.Format("{0}/pessoa/pessoa?cpfValue={1}", "https://localhost:44346", cpfValue);
            //string details = CallRestMethod(url);

            Console.WriteLine("Os dados da Pessoa são: ");
            Console.WriteLine("Nome: " + details.Nome);
            Console.WriteLine("Nome: " + details.Data_nascimento);
            Console.WriteLine("CPF: " + details.Cpf);
            Console.WriteLine("CEP: " + details.Endereco.Cep);
            Console.WriteLine("Pais: " + details.Endereco.Pais.Nome);
            Console.WriteLine("Estado: " + details.Endereco.Estado.Nome);
            Console.WriteLine("Cidade: " + details.Endereco.Cidade.Nome);
            Console.WriteLine("Logradouro: " + details.Endereco.Logradouro);
            Console.WriteLine("Número: " + details.Endereco.Numero);
            Console.WriteLine("Complemento: " + details.Endereco.Complemento);






            //printa a resposta
            Console.WriteLine("Pressione qualquer tecla para sair.");
                Console.ReadKey();

                //mensagem de encerramento
                Console.WriteLine("Pressione qualquer tecla para sair.");
                Console.ReadKey();
            





        }


        public static string CallRestMethod(string url)
        {
            HttpWebRequest webrequest = (HttpWebRequest)WebRequest.Create(url);
            webrequest.Method = "GET";
            webrequest.ContentType = "application/x-www-form-urlencoded";
            webrequest.Headers.Add("Username", "xyz");
            webrequest.Headers.Add("Password", "abc");
            HttpWebResponse webresponse = (HttpWebResponse)webrequest.GetResponse();
            Encoding enc = System.Text.Encoding.GetEncoding("utf-8");
            StreamReader responseStream = new StreamReader(webresponse.GetResponseStream(), enc);
            string result = string.Empty;
            result = responseStream.ReadToEnd();
            webresponse.Close();
            return result;
        }

    }
}

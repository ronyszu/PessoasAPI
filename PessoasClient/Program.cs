using Newtonsoft.Json;
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


            //chamada para a API

            string url = string.Format("{0}/pessoa/getPessoa?cpfValue={1}", "https://localhost:44346", cpfValue);
            string details = CallRestMethod(url);


            var dadosPessoa = JsonConvert.DeserializeObject<PessoaDAO>(details);


            Console.WriteLine("Os dados da Pessoa são: ");
            Console.WriteLine("Nome: " + dadosPessoa.Nome);
            Console.WriteLine("Data: " + dadosPessoa.Data_nascimento);
            Console.WriteLine("CPF: " + dadosPessoa.Cpf);
            Console.WriteLine("CEP: " + dadosPessoa.Endereco.Cep);
            Console.WriteLine("Pais: " + dadosPessoa.Endereco.Pais.Nome);
            Console.WriteLine("Estado: " + dadosPessoa.Endereco.Estado.Nome);
            Console.WriteLine("Cidade: " + dadosPessoa.Endereco.Cidade.Nome);
            Console.WriteLine("Logradouro: " + dadosPessoa.Endereco.Logradouro);
            Console.WriteLine("Número: " + dadosPessoa.Endereco.Numero);
            Console.WriteLine("Complemento: " + dadosPessoa.Endereco.Complemento);



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
            webrequest.ContentType = "application/json";
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

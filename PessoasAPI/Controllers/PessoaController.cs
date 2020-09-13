using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PessoasAPI.Classes;
using static PessoasAPI.Program;

namespace PessoasAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PessoaController : ControllerBase
    {
       


// private readonly ILogger<Pessoa> _logger;

//public PessoaController(ILogger<PessoaController> logger)
//{
//    _logger = logger;
//}

        [HttpGet("pessoa")]
        public Pessoa GetPessoa(string cpfValue)
        {
            Pessoa pessoa = new Pessoa();

            try
            {

                string queryString =  @"SELECT dbo.pessoa.nome, dbo.pessoa.cpf, dbo.pessoa.data_nascimento, dbo.pais.nome AS Pais, dbo.estado.nome AS Estado, dbo.cidade.nome AS Cidade, dbo.endereco.cep, dbo.endereco.logradouro, dbo.endereco.numero, 
                      dbo.endereco.complemento
                FROM  dbo.cidade INNER JOIN
                      dbo.endereco ON dbo.cidade.id = dbo.endereco.cidade_fk INNER JOIN
                      dbo.estado ON dbo.endereco.estado_fk = dbo.estado.id INNER JOIN
                      dbo.pais ON dbo.endereco.pais_fk = dbo.pais.id INNER JOIN
                      dbo.pessoa ON dbo.endereco.id = dbo.pessoa.endereco_fk
                WHERE(cpf = " + cpfValue + ")";


                //string queryString = "SELECT *  FROM  pessoa WHERE cpf=" + cpfValue;

                string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=PessoasDB;Integrated Security=True;";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(queryString, connection);
                    
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();



                    try
                    {
                        while (reader.Read())
                        {
                            pessoa.Nome = reader["nome"].ToString();
                            pessoa.Data_nascimento = reader["data_nascimento"].ToString();
                            pessoa.Cpf = cpfValue;

                            Endereco endereco = new Endereco();
                            Pais pais = new Pais();
                            Cidade cidade = new Cidade();
                            Estado estado = new Estado();


                            endereco.Cep = reader["cep"].ToString();
                            endereco.Complemento = reader["complemento"].ToString();
                            endereco.Logradouro = reader["logradouro"].ToString();
                            endereco.Numero =(int)reader["numero"];
                            pais.Nome = reader["pais"].ToString();
                            estado.Nome = reader["estado"].ToString();
                            cidade.Nome = reader["cidade"].ToString();


                            pessoa.Endereco = endereco;
                            pessoa.Endereco.Pais = pais;
                            pessoa.Endereco.Estado = estado;
                            pessoa.Endereco.Cidade = cidade;

                        }
                    }
                    finally
                    {
                        // Always call Close when done reading.
                        reader.Close();
                        
                    }
                }


            }
            catch (Exception e)
            {

                Console.WriteLine("Não foi encontrada nenhuma pessoa com este CPF, por favor tente novamente.");
            }




            return pessoa;


        }
    }
}

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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

                string queryString = "SELECT *  FROM  pessoa WHERE cpf=" + cpfValue;

                //string queryString = "SELECT *  FROM  dbo.pessoa";

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
                            //pessoa.Endereco = reader["endereco"].ToString();
                            pessoa.Data_nascimento = reader["data_nascimento"].ToString();
                            pessoa.Cpf = cpfValue;

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

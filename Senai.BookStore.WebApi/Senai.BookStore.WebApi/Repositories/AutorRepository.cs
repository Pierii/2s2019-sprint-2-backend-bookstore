using Senai.BookStore.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.BookStore.WebApi.Repositories
{
    public class AutorRepository
    {
        private string StringConexao = "Data Source=.\\SqlExpress; Initial catalog=M_BookStore; User Id=sa; Pwd=132";

        public List<AutorDomain> Listar()
        {

        List<AutorDomain> autores = new List<AutorDomain>();
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string Query = "SELECT * FROM Autores ORDER BY IdAutor ASC";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(Query, con))

                    rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    AutorDomain autor = new AutorDomain
                    {
                        IdAutor = Convert.ToInt32(rdr["IdAutor"]),
                        Nome = rdr["Nome"].ToString(),
                        Email = rdr["Email"].ToString(),
                        Ativo = Convert.ToByte(rdr["Ativo"]),
                        DataNascimento = Convert.ToDateTime(rdr["DataNascimento"])
                    };
                    autores.Add(autor);
                }
            }
            return autores;
        }

        public void Cadastrar(AutorDomain autor)
        {
            string Query = "INSERT INTO Autores (Nome, Email, Ativo, DataNascimento) VALUES (@Nome, @Email, @Ativo, @DataNascimento)";

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@Nome", autor.Nome);
                cmd.Parameters.AddWithValue("@Email", autor.Email);
                cmd.Parameters.AddWithValue("@Ativo", autor.Ativo);
                cmd.Parameters.AddWithValue("@DataNascimento", autor.DataNascimento);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}

using Senai.BookStore.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.BookStore.WebApi.Repositories
{
    public class GeneroRepository
    {
        private string StringConexao = "Data Source=.\\SqlExpress; Initial catalog=M_BookStore; User Id=sa; Pwd=132";

        public List<GeneroDomain> Listar()
        {

            List<GeneroDomain> generos = new List<GeneroDomain>();
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string Query = "SELECT * FROM Generos ORDER BY IdGenero ASC";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(Query, con))

                    rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    GeneroDomain genero = new GeneroDomain
                    {
                        IdGenero = Convert.ToInt32(rdr["IdGenero"]),
                        Descricao = rdr["Descricao"].ToString()
                    };
                    generos.Add(genero);
                }
            }
            return generos;
        }

        public void Cadastrar(GeneroDomain genero)
        {
            string Query = "INSERT INTO Generos (Descricao) VALUES (@Descricao)";

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@Descricao", genero.Descricao);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}

using Dapper;
using Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class AmigoRepository
    {

        private string ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=AmigosDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";


        public List<Amigo> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(this.ConnectionString))
            {
                return connection.Query<Amigo>("SELECT * FROM AMIGO").ToList();
            }

        }
        public Amigo GetAmigoById(Guid id)
        {
            using(SqlConnection connection = new SqlConnection(this.ConnectionString))
            {
                return connection.QueryFirstOrDefault<Amigo>("SELECT * FROM AMIGO WHERE ID = @P1", new { P1 = id });
            }
        }

        public void Save(Amigo amigo)
        {
            using (SqlConnection connection = new SqlConnection(this.ConnectionString))
            {
                connection.Execute(@"INSERT INTO AMIGO(ID, NOME, SOBRENOME, EMAIL, DATANASCIMENTO, STATUS)
                                            VALUES(@P1,@P2,@P3,@P4,@P5,@P6)
                ", new { P1 = amigo.Id, P2 = amigo.Nome, P3 = amigo.SobreNome, P4 = amigo.Email, P5 = amigo.DataNascimento, P6 = amigo.Status });
            }
        }

        public Amigo GetAmigoByEmail(string email)
        {
            using (SqlConnection connection = new SqlConnection(this.ConnectionString))
            {
                return connection.QueryFirstOrDefault<Amigo>("SELECT * FROM AMIGO WHERE EMAIL = @P1", new { P1 = email });
            }
        }

        public void Deletar(Guid id)
        {
            using (SqlConnection connection = new SqlConnection(this.ConnectionString))
            {
                connection.Execute("DELETE FROM AMIGO WHERE ID = @P1", new { P1 = id });
            }
        }

        
    }


}

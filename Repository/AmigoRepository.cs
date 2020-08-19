using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class AmigoRepository
    {
        private static List<Amigo> Amigos { get; set; } = new List<Amigo>();

        public List<Amigo> GetAll()
        {
            return Amigos;
        }
        public Amigo GetAmigoById(Guid id)
        {
            return Amigos.FirstOrDefault(x => x.Id == id);

        }

        public void Save(Amigo amigo)
        {
            Amigos.Add(amigo);
        }

        public Amigo GetAmigoByEmail(string email)
        {
            return Amigos.FirstOrDefault(x => x.Email == email);
        }

        public void Deletar(Guid Id)
        {
            var amigo = this.GetAmigoById(Id);

            if (amigo != null)
                Amigos.Remove(amigo);
        }

        
    }


}

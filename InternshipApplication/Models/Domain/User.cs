using System;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;

namespace InternshipApplication.Models.Domain
{
    //kunnen geen User objecten rechtstreeks in de db, ofwel bedrijf, student, stagebegeleider
    public abstract class User
    {
        private int id;
        private String emailadres;
        private String password;

        

        public User()
        {
            
        }

        public String Emailadres{ get; set; }
        public int Id { get; set; }
        public String Password
        {
            get { return this.password; }
            set { this.password = sha256_hash(value); }
        }
       
        public String sha256_hash(String value)
        {
            StringBuilder Sb = new StringBuilder();

            using (SHA256 hash = SHA256Managed.Create())
            {
                Encoding enc = Encoding.UTF8;
                Byte[] result = hash.ComputeHash(enc.GetBytes(value));

                foreach (Byte b in result)
                    Sb.Append(b.ToString("x2"));
            }

            return Sb.ToString();
        }
    }
}

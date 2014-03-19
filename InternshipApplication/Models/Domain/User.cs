using System;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;

namespace InternshipApplication.Models.Domain
{
    //kunnen geen User objecten rechtstreeks in de db, ofwel bedrijf, student, stagebegeleider
    public abstract class User
    {


        public User()
        {
            
        }

        public String Emailadres{ get; set; }
        public int Id { get; set; }
  
        }
       

    }


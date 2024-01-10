using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassSenseCore.Entities
{
    public class Instructor
    {
        //public Instructor()
        //{
        //    Sections = new HashSet<Section>();
        //}

        [Key]
        public int ID { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public byte[] ProfilePic { get; set; }
        public bool IsAdmin { get; set; }

        public ICollection<Section> Sections { get; set; }

    }

}

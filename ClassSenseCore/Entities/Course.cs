using Org.BouncyCastle.Pqc.Crypto.Lms;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassSenseCore.Entities
{
    public class Course
    {
        //public Course()
        //{
        //    Sections = new HashSet<Section>();
        //}

        [Key]
        public int ID { get; set; }
        [StringLength(10)]
        public  string Code { get; set; }
        [StringLength(50)]
        public string Name { get; set; }

        public ICollection<Section>  Sections { get; set; }

    }

}

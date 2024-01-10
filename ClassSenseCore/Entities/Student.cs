using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassSenseCore.Entities
{
    public class Student
    {
        //public Student()
        //{
        //    Images = new ;
        //    Attends = new HashSet<Attend>();
        //    Enrolleds = new HashSet<Enrolled>();
        //}
        [Key]
        public int ID { get; set; }
        public string Fname { get; set; }
        public string LName { get; set; }
        public string Email { get; set; }

        public ICollection<Images> Images { get; set; }
        public ICollection<Attend> Attends { get; set; }
        public ICollection<Enrolled> Enrolleds { get; set; }


    }

}

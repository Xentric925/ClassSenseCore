using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassSenseCore.Entities
{
    public class Enrolled
    {
        [Key]
        public int ID { get; set; }
        public string Semester { get; set; }


        public int StudentID { get; set; }
        [ForeignKey(nameof(StudentID))]

        public Student Student { get; set; }
        
        
        public int SectionID { get; set; }
        [ForeignKey(nameof(SectionID))]

        public Section Section { get; set; }

    }

}

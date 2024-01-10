using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassSenseCore.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Attend
    {
        [Key]
        public int ID { get; set; }



        public int StudentID { get; set; }
        [ForeignKey(nameof(StudentID))]
        public Student Student { get; set; }
       
        
        public int SectionID { get; set; }  
        [ForeignKey(nameof(SectionID))]
        public Section Section { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; }
        public bool IsPresent { get; set; }
    }

}

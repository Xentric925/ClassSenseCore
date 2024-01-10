using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassSenseCore.Entities
{
    public class Section
    {
        //public Section()
        //{
        //    Attends = new HashSet<Attend>();
        //}

        [Key]
        public int ID { get; set; }
        public string SectionLetter { get; set; }
        public string Days { get; set; }
        public string Slot { get; set; }
               
        public int CourseID { get; set; }  
        [ForeignKey(nameof(CourseID))]

        public Course Course { get; set; }
        
        public int RoomID { get; set; }
        [ForeignKey(nameof(RoomID))]
        public Room Room { get; set; }
         
        public int InstructorID { get; set; }    
        [ForeignKey(nameof(InstructorID))]

        public Instructor Instructor { get; set; }

        public ICollection<Attend> Attends { get; set; }

    }

}

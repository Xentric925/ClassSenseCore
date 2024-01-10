using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ClassSenseCore.Entities
{
    public class Images
    {
        [Key]
        public int ID { get; set; }
        public string URL { get; set; }


        public int StudentID { get; set; }

        [ForeignKey(nameof(StudentID))]
        public Student Student { get; set; }
    }

}

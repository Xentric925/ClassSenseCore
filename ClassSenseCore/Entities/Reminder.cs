using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassSenseCore.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Reminder
    {
        [Key]
        public int ID { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public bool IsDone { get; set; }
    }

}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassSenseCore.Entities
{
    public class Room
    {
        //public Room()
        //{
        //    Sections = new HashSet<Section>();
        //}
        [Key]
        public int ID { get; set; }
        public string Code { get; set; }

        public ICollection<Section> Sections { get; set; }

    }

}

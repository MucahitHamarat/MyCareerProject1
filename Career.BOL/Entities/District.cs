using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Career.BOL.Entities
{
    [Table("District")]
    public class District
    {
        public int ID { get; set; }

        [StringLength(30), Column(TypeName = "varchar")]
        public string Name { get; set; }

        public int CityPlaque { get; set; }
        public City Cities { get; set; }
    }
}

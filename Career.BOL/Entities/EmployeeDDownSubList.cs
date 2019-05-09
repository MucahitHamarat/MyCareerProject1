using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Career.BOL.Entities
{
    [Table("EmployeeDDownSubList")]
    public class EmployeeDDownSubList
    {
        public int ID { get; set; }

        [StringLength(60), Column(TypeName = "varchar")]
        public string Name { get; set; }

        public int FindEmployeeCatsID { get; set; }
        public FindEmployeeCats FindEmployeeCatses { get; set; }
    }
}

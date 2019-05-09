using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Career.BOL.Entities
{
    [Table("FindEmployeeCats")]
    public class FindEmployeeCats
    {
        public int ID { get; set; }
        //public ICollection<FindEmployeeSubCats> FindEmployeeSubCatses { get; set; }

        [StringLength(100), Column(TypeName = "varchar")]
        public string CatName { get; set; }

    }
}



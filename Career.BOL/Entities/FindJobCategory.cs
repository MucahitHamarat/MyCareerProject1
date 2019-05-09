using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Career.BOL.Entities
{
    [Table("FindJobCategory")]
    public class FindJobCategory
    {
        public int ID { get; set; }

        [StringLength(60), Column(TypeName = "varchar")] 
        public string Name { get; set; }

        public ICollection<FindJobSubCategory> FindJobSubCategories { get; set; }
    } 
}

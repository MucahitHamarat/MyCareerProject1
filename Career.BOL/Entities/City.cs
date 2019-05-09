using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Career.BOL.Entities
{
    [Table("City")]
    public class City
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Plaque { get; set; }

        [StringLength(30), Column(TypeName = "varchar")]
        public string Name { get; set; }

        public ICollection<District> Districts { get; set; }
        public ICollection<FindEmployeeSubCatsCity> findEmployeeSubCatsCity { get; set; }


    }
}

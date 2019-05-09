using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Career.BOL.Entities
{
    public class FindEmployeeSubCatsCity
    {
         
        [Key,Column(Order=1)]
        public int CityPlaque { get; set; }
        public City cities { get; set; }

        [Key, Column(Order = 2)]
        public int FindEmployeeSubCatsID { get; set; }
        public FindEmployeeSubCats findEmployeeSubCats { get; set; }
    }
}

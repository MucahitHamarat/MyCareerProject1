using Career.BOL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace itcareernet.ViewModels
{
    public class JobsWithCities
    {
        public FindEmployeeSubCats findEmployeeSubCats { get; set; }
        public ICollection<City> cities { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Career.BOL.Entities
{
    [Table("FindEmployeeSubCats")]
    public class FindEmployeeSubCats
    {
        public int ID { get; set; }

       
        [StringLength(100), Column(TypeName = "varchar")]
        public string CompanyName { get; set; }

        [StringLength(100), Column(TypeName = "varchar")]
        public string JobTitle { get; set; }

        [StringLength(100), Column(TypeName = "varchar")]
        public string Email { get; set; }

        [StringLength(3000), Column(TypeName = "varchar")]
        public string Description { get; set; }

        
        [Display(Name = "Logo")]
        public string Logo { get; set; }

        public ICollection<FindEmployeeSubCatsCity> findEmployeeSubCatsCity { get; set; }

        public MilitaryState MilitaryState { get; set; } 
        public Experience Experience { get; set; }
        public JobType JobType { get; set; }
        public PosLevel PosLevel { get; set; }
    }

    public enum MilitaryState
    {
        Yapıldı = 1,
        Muaf,
        Tecilli
    }

    public enum Experience
    {
        Deneyimli = 1,
        Deneyimsiz,
        Deneyimli_Deneyimsiz
    }

    public enum JobType
    {
        Fulltime = 1,
        Parttime,
        Freelance
    }

    public enum PosLevel
    {
        New_Starter = 1,
        Junior,
        Mid_Level,
        Senior
    }
}

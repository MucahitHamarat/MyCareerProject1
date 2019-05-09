//using Career.BOL.Entities;
using Career.BOL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
//using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Career.DAL.Context
{
    public class MyContext:DbContext
    {
        public DbSet<City> City { get; set; }
        public DbSet<District> District { get; set; }
        public DbSet<FindJobCategory> FindJobCategory { get; set; }
        public DbSet<FindJobSubCategory> FindJobSubCategory { get; set; }         
        public DbSet<FindEmployeeCats> FindEmployeeCats { get; set; } 
        public DbSet<FindEmployeeSubCats> FindEmployeeSubCats { get; set; } 
        public DbSet<EmployeeDDownSubList> EmployeeDDownSubList { get; set; } 
        public DbSet<Specialization> Specialization { get; set; }   
        public DbSet<Category> Category { get; set; }  
        public DbSet<Admin> Admin { get; set; }  
        public DbSet<Member> Member { get; set; }       
        public DbSet<FindEmployeeSubCatsCity> FindEmployeeSubCatsCity { get; set; }  

 
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Career.BOL.Entities
{
    [Table("Admin")]
    public class Admin
    {
        [Key, StringLength(30), Column(TypeName = "Varchar"), Display(Name = "Kullanıcı Adı"), Required(ErrorMessage = "Kullanıcı Adı boş geçilemez.")]
        public string Username { get; set; }

        [StringLength(80), Column(TypeName = "varchar"), Display(Name = "Mail Adresi"), Required(ErrorMessage = "Mail adresi boş geçilemez.")]
        public string Email { get; set; }

        [StringLength(20), Column(TypeName = "Varchar"), Display(Name = "Şifre"), Required(ErrorMessage = "Şifre boş geçilemez."), DataType(DataType.Password)]
        public string Password { get; set; }

        [NotMapped, Column(TypeName = "Varchar"), Compare("Sifre", ErrorMessage = "Şifreler uyuşmuyor"), DataType(DataType.Password)]
        public string Password2 { get; set; }

        [DataType(DataType.DateTime), Display(Name = "Son Giriş Tarihi")]
        public DateTime LastDate { get; set; }

        [StringLength(20), Column(TypeName = "Varchar"), Display(Name = "Son Giriş IP Adresi")]
        public string LastIP { get; set; }

        [StringLength(10), Column(TypeName = "Varchar"), Display(Name = "Rolü")]
        public string Role { get; set; }
        [Required(ErrorMessage = "Bu şartları kabul etmez zorunludur")]
        public bool Acceptation { get; set; }
    }
}

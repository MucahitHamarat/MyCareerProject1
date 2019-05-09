
using Career.BLL.Repositories;
using Career.BOL.Entities;
using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace itcareernet.Controllers
{
    public class HomeController : Controller
    {
        Repository<Category> repoCategory = new Repository<Category>();
       
        Repository<Admin> repoAdmin = new Repository<Admin>();
        Repository<Member> repoMember = new Repository<Member>();
        Repository<FindJobCategory> repoFindJobCategory = new Repository<FindJobCategory>();
        Repository<FindEmployeeCats> repoFindEmployeeCats = new Repository<FindEmployeeCats>();
       
        
        public ActionResult Index()
        {
           
            ViewBag.FindJobCategory = new SelectList(repoFindJobCategory.GetAll().ToList(), "ID", "Name");
            ViewBag.FindEmployeeCats = new SelectList(repoFindEmployeeCats.GetAll().ToList(), "ID", "CatName");
            return View();

        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact()
        {
            //ViewBag.Message = "Your contact page.";
            return View();
        }



        public ActionResult Registration()
        {
            return View();
        }
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Registration(string username, string MailAddress, string password, string password2, bool acceptation)
        {
            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password) && !string.IsNullOrEmpty(password2) && !string.IsNullOrEmpty(MailAddress))
            {
                if (repoMember.GetAll().Any(a => a.Email == MailAddress))
                {
                    TempData["Hata"] = "Mail kullanılamaz.";
                    return Redirect("/Member/Index?t=yeni");
                }
                if (password == password2 && acceptation == true)
                {
                    repoMember.Add(new Member
                    {
                        Username = username,
                        Email = MailAddress,
                        Password = password,
                        Password2 = password2,
                        LastDate = Convert.ToDateTime(DateTime.Now),
                        LastIP = Request.UserHostAddress,
                        Role = "uye"
                    });
                    TempData["Kaydedildi"] = "Tebrikler!Kaydınız Başarıyla Oluşturuldu.";
                    Member member = repoMember.GetBy(a => a.Email == MailAddress && a.Password == password);
                    FormsAuthentication.SetAuthCookie(MailAddress, true);
                    Session["AdSoyad"] = member.Username;
                    return Redirect("/");
                }


                else
                {
                    TempData["Hata"] = "Şifreler uyuşmuyor.";
                    return Redirect("/Member/Index?t=yeni");
                }

            }
            else TempData["Hata"] = "Alanları doldurunuz.";
            return Redirect("/Member/Index?t=yeni");
        }
        public ActionResult SignIn(string ReturnUrl)
        {
            if (User.Identity.IsAuthenticated) FormsAuthentication.SignOut(); /*eğer kullanıcı girmişse çıkış yap*/
            ViewBag.rtn = ReturnUrl;
            return View();

        }
        [HttpPost,ValidateAntiForgeryToken]
        public ActionResult SignIn(string username,string pass, string rUrl)
        {
            //eğer Rolü admin ise admine,değilse site ana sayfasına
            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(pass))
            {
                Admin admin = repoAdmin.GetBy(a => a.Username == username && a.Password == pass);
                if (admin != null)
                {
                    FormsAuthentication.SetAuthCookie("#" + username, true);
                    Session["AdSoyad"] = admin.Username;           
                    if (!string.IsNullOrEmpty(rUrl)) return Redirect(rUrl);
                    else return Redirect("/admin");
                }
                else
                {
                    ViewBag.Hata = "Kullanıcı Adı veya Şifre Hatalı";
                }
            }
            else ViewBag.Hata = "Kullanıcı Adı ve Şifre Gerekli";
            return View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("SignIn");
        }

        public ActionResult Header()
        {         
            return PartialView(repoCategory.GetAll());
        }

        public ActionResult ChangeLang(string langX, string returnURL)
        {
            HttpCookie httpCookie = new HttpCookie("CKDil");
            httpCookie.Value = langX;
            Response.Cookies.Add(httpCookie);
            return Redirect(returnURL);
        }
    }
}
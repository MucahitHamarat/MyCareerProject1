using Career.BLL.Repositories;
using Career.BOL.Entities;
using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using Facebook;
using Newtonsoft.Json;
namespace itcareernet.Controllers
{
    public class MemberController : Controller
    {
        Repository<Member> repoMember = new Repository<Member>();
        Repository<FindJobCategory> repoFindJobCategory = new Repository<FindJobCategory>();
        Repository<FindEmployeeCats> repoFindEmployeeCats = new Repository<FindEmployeeCats>();
     private Uri RedirectUri
        {
            get
            {
                var uriBuilder = new UriBuilder(Request.Url);
                uriBuilder.Query = null;
                uriBuilder.Fragment = null;
                uriBuilder.Path = Url.Action("facebookCallback");
                return uriBuilder.Uri;
            }
        }
        [AllowAnonymous]
        public ActionResult Facebook()
        {
            var fb = new FacebookClient();
            var loginUrl = fb.GetLoginUrl(new
            {
                client_id = "Your facebook api Client id here",
                client_secret = "Your fecebook api secret key here",
                redirect_uri = RedirectUri.AbsoluteUri,
                response_type = "code",
                scope="email"
            }
                );
            return Redirect(loginUrl.AbsoluteUri);
        }

        public ActionResult FacebookCallback(string code)
        {
            var fb = new FacebookClient();
            dynamic result = fb.Post("oauth/access_token",new
            {
                client_id = "Your facebook api Client id here",
                client_secret = "Your fecebook api secret key here",
                redirect_uri = RedirectUri.AbsoluteUri,
                code=code
            }
            );
            var accessToken = result.access_token;
            Session["AccessToken"] = accessToken;
            fb.AccessToken = accessToken;
            dynamic me = fb.Get("me?fields=link,first_name,currency,last_name,email,gender,locale,timezone,verified,picture,age_range");
            string email = me.email;
            string lastname = me.lsat_name;
            string picture = me.picture.data.url;
            FormsAuthentication.SetAuthCookie(email, false);
            return RedirectToAction("Index", "Member");
        }
        public ActionResult Index()
        {
            
            ViewBag.FindJobCategory = new SelectList(repoFindJobCategory.GetAll().ToList(), "ID", "Name");
            ViewBag.FindEmployeeCats = new SelectList(repoFindEmployeeCats.GetAll().ToList(), "ID", "CatName");
            return View();
        }
        public ActionResult SignIn(string ReturnUrl)
        {
            if (User.Identity.IsAuthenticated) FormsAuthentication.SignOut(); /*eğer kullanıcı girmişse çıkış yap*/
            ViewBag.rtn = ReturnUrl;
            return View();

        }
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult SignIn(string Username, string pass)
        {
            string sifre = FormsAuthentication.HashPasswordForStoringInConfigFile(pass, "MD5");
            if (!string.IsNullOrEmpty(Username) && !string.IsNullOrEmpty(pass))
            {
                Member member = repoMember.GetBy(a => a.Email == Username && a.Password == sifre);
                if (member != null)
                {
                    FormsAuthentication.SetAuthCookie(Username, true);
                    Session["MemberID"] = member.ID;
                    Session["AdSoyad"] = member.Username;
                    return Redirect("/");
                }
                else
                {
                    TempData["Hata"] = "Mail Adresi veya Şifre Hatalı";
                    return View();
                }
            }
            else TempData["Hata"] = "Mail Adresi veya Şifre boş geçilemez";
            return RedirectToAction("Index");
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return Redirect("/");
        }

        public ActionResult Registration()
        {
            return View();
        }
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Registration(string username, string Email, string password, string password2,bool acceptation)
        {

            if (!string.IsNullOrEmpty(username)  && !string.IsNullOrEmpty(password) && !string.IsNullOrEmpty(password2) && !string.IsNullOrEmpty(Email))
            {
                if (repoMember.GetAll().Any(a => a.Email == Email))
                {
                    TempData["Hata"] = "Mail kullanılamaz.";
                    return Redirect("/Member/Index?t=yeni");
                }
                if (password == password2 && acceptation == true)
                {
                    repoMember.Add(new Member {
                        Username = username,
                        Email = Email,
                        Password = FormsAuthentication.HashPasswordForStoringInConfigFile(password, "MD5"),
                        Password2 = password2,
                        LastDate = Convert.ToDateTime(DateTime.Now),
                        LastIP = Request.UserHostAddress,
                        Role = "uye" });
                    TempData["Kaydedildi"] = "Tebrikler!Kaydınız Başarıyla Oluşturuldu.";
                    //Member member = repoMember.GetBy(a => a.Email == Email && a.Password == password);
                    FormsAuthentication.SetAuthCookie(Email, true);
                    Session["AdSoyad"] = username;
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
    }
}
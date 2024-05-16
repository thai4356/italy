using Microsoft.AspNetCore.Mvc;
using Italian_Restaurant_1.Models;

namespace Italian_Restaurant_1.Controllers
{
    public class AccessController : Controller
	{
		ItalyContext db = new ItalyContext();
        [HttpGet]
        public ActionResult Login()
        {
            if (HttpContext.Session.GetString("Username") == null)
            {
				return View();						
            }
            else
            {
				return RedirectToAction("Index", "Home");
			}
        }
        [HttpPost]
        public IActionResult Login(User user)
        {
            if (HttpContext.Session.GetString("Username") == null)
            {
                var u = db.Users.Where(x => x.Username.Equals(user.Username) && x.Pass.Equals(user.Pass)).FirstOrDefault();
               
                if (u!=null)
                {                  
                    HttpContext.Session.SetString("Username", u.Username.ToString());
                    HttpContext.Session.SetString("UserRole", u.UserRole.ToString());
                    if (string.Equals(u.UserRole.ToString(), "1", StringComparison.CurrentCultureIgnoreCase))
                    {
                        return RedirectToAction("Index", "Admin");
                    }
                    else if(string.Equals(u.UserRole.ToString(), "0", StringComparison.CurrentCultureIgnoreCase))
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                
            }
            return View();
        }

		public IActionResult Logout()
		{
			HttpContext.Session.Clear();
			HttpContext.Session.Remove("UserName");
			return RedirectToAction("Index", "Home");
		}
	}
}

using Microsoft.AspNetCore.Mvc;

namespace Tutor_NET105_SM2024_BL1.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login(string username, string password)// đăng nhập
        {
            if (username == null && password == null) // chưa có data gì cả
            {
                TempData["login"] = "Bạn chưa đăng nhập";
                return View();
            }
            else
            {
                // Kiểm tra tài khoản
                if(username != "admin" && password != "123456") {
                    HttpContext.Session.SetString("account", username); // Lưu dữ liệu đăng nhập vào Session
                    TempData["login"] = $"Chào mừng {username} đã đăng nhập với quyền Khách";
                    return RedirectToAction("Index", "Home"); // Trở về trang Home
                }else
                {
                    HttpContext.Session.SetString("account", username); // Lưu dữ liệu đăng nhập vào Session
                    TempData["login"] = $"Chào mừng {username} đã đăng nhập với quyền Admin";
                    return RedirectToAction("Index", "Home"); // Trở về trang Home
                }
            }
        } // Viết hoặc dùng chatGPT gen 1 cái View Login có 2 textBox để nhập username, password
          // và 1 nút login ứng với Action Login(string username, string password) không dùng model
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("account"); // Xóa dữ liệu của Session với key nào đó
            return RedirectToAction("Index", "Home");
        }
    }
}

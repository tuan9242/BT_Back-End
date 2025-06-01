using Microsoft.AspNetCore.Mvc;
using Lab_4.Models;

namespace Lab_4.Controllers
{
    public class UserController : Controller
    {
        private static List<User> users = new List<User>
        {
            new User { Id = "SV001", Username = "admin", Password = "123456", Email = "admin@example.com", Phone = "0123456789" },
            new User { Id = "SV002", Username = "user01", Password = "password", Email = "user01@example.com", Phone = "0987654321" }
        };
        public IActionResult Index()
        {
            return View(users);
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(User user)
        {
            if (ModelState.IsValid)
            {
                // Kiểm tra trùng lặp ID
                if (users.Any(u => u.Id == user.Id))
                {
                    ModelState.AddModelError("Id", "Mã sinh viên đã tồn tại!");
                    return View(user);
                }

                // Kiểm tra trùng lặp Username
                if (users.Any(u => u.Username == user.Username))
                {
                    ModelState.AddModelError("Username", "Tài khoản đã tồn tại!");
                    return View(user);
                }

                users.Add(user);
                TempData["SuccessMessage"] = "Thêm người dùng thành công!";
                return RedirectToAction("Index");
            }

            return View(user);
        }

        // GET: User/Edit/5
        public IActionResult Edit(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }

            var user = users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: User/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                var existingUser = users.FirstOrDefault(u => u.Id == user.Id);
                if (existingUser == null)
                {
                    return NotFound();
                }

                // Kiểm tra trùng lặp Username (trừ chính user hiện tại)
                if (users.Any(u => u.Username == user.Username && u.Id != user.Id))
                {
                    ModelState.AddModelError("Username", "Tài khoản đã tồn tại!");
                    return View(user);
                }

                existingUser.Username = user.Username;
                existingUser.Password = user.Password;
                existingUser.Email = user.Email;
                existingUser.Phone = user.Phone;

                TempData["SuccessMessage"] = "Cập nhật người dùng thành công!";
                return RedirectToAction("Index");
            }

            return View(user);
        }

        // GET: User/Details/5
        public IActionResult Details(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }

            var user = users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: User/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(string id)
        {
            var user = users.FirstOrDefault(u => u.Id == id);
            if (user != null)
            {
                users.Remove(user);
                TempData["SuccessMessage"] = "Xóa người dùng thành công!";
            }

            return RedirectToAction("Index");
        }
    }
}

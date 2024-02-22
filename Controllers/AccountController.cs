using FutureCloudContactManager.Models;
using FutureCloudContactManager.Models.Enums;
using FutureCloudContactManager.Models.ViewModel;
using FutureCloudContactManager.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FutureCloudContactManager.Controllers
{


    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly ITokenService _tokenService;
        private readonly SignInManager<User> _signInManager;
        public AccountController(UserManager<User> userManager, ITokenService tokenService, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _tokenService = tokenService;
            _signInManager = signInManager;
        }
        // GET: AccountController
        [HttpGet]
        public IActionResult Register()
        {
            var registerVM = new RegisterVM();


            return View(registerVM);
        }

        [HttpPost]

        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if (ModelState.IsValid)
            {
                var userm = await _userManager.FindByEmailAsync(registerVM.Email);
                if (userm == null)
                {

                    if (registerVM.Password == registerVM.ConfirmPassword)
                    {
                        var user = new User
                        {
                            FirstName = registerVM.FirstName,
                            LastName = registerVM.LastName,
                            Email = registerVM.Email,
                            NIN = registerVM.NIN
                            

                        };
                        user.UserName = registerVM.Email;
                        var result = await _userManager.CreateAsync(user, registerVM.Password);
                        if (result.Succeeded)
                        {
                            await _userManager.AddToRoleAsync(user, UserType.NewUser.ToString());
                            return RedirectToAction(nameof(SignUpSuccess));

                        }
                        else
                        {
                            foreach (var error in result.Errors)
                            {
                                ModelState.TryAddModelError("Others", error.Description);

                            }

                        }

                    }
                    else
                    {
                        ModelState.TryAddModelError("ConfirmPassword", "Password is not the same as Confirm Password");
                    }
                }

                else
                {
                    ModelState.TryAddModelError("Email", $"Email {registerVM.Email} already exist");
                }


            }
            return View(registerVM);
        }

        // GET: AccountController/Create
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            var user = await _userManager.FindByEmailAsync(loginVM.Email);
            if (user != null)
            {
                var result = await _userManager.CheckPasswordAsync(user, loginVM.Password);
                if (result)
                {
                    var signIn = await _signInManager.PasswordSignInAsync(user, loginVM.Password, false, false);
                    if (signIn.Succeeded)
                    {

                        var token = await _tokenService.CreateToken(user);
                        return RedirectToAction("AllContact", "Contact");
                    }
                }
                else
                {
                    ModelState.TryAddModelError("Not Successfuk", "Wrong Password");
                }
            }
            else
            {
                ModelState.TryAddModelError("Not Successful", "User not found");
            }
            return View();
        }

        public IActionResult SignUpSuccess()
        {
            return View();
        }

        // POST: AccountController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AccountController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AccountController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AccountController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AccountController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

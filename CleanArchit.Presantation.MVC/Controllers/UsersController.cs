using AutoMapper;
using CleanArchit.Presantation.MVC.Models;
using CleanArchit.Presantation.MVC.Models.AdminModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using Microsoft.AspNetCore.WebUtilities;

namespace CleanArchit.Presantation.MVC.Controllers
{
    public class UsersController : Controller
    {
        private UserManager<TeacherIdentity> _userManager;
        private IUserStore<TeacherIdentity> _userStore;
        private IUserEmailStore<TeacherIdentity> _emailStore;
        private IMapper _mapper;
        private RoleManager<IdentityRole> _roleManager;

        public UsersController(
            UserManager<TeacherIdentity> userManager,
            IUserStore<TeacherIdentity> userStore,
            IMapper mapper,
            RoleManager<IdentityRole> roleManager) 
        {
            _userManager = userManager;
            _userStore = userStore;
            _emailStore = GetEmailStore();
            _mapper = mapper;
            _roleManager = roleManager;
        }

        public IActionResult Index() => View(_userManager.Users.ToList());

        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(CreateUserViewModel userModel)
        {
            if(ModelState.IsValid)
            {
                TeacherIdentity teacher = new TeacherIdentity
                {
                    UserName = userModel.UserName,
                    Email = userModel.Email,
                    Name = userModel.Name,
                    DateOfBirth = userModel.DateOfBirth,
                    PhoneNumber = userModel.PhoneNumber,
                    SecondName = userModel.SecondName,
                    Sirname = userModel.Sirname,
                };
                var user = _mapper.Map<TeacherIdentity>(teacher);
                if(userModel.Role == "Admin")
                {
                    await _userManager.AddToRoleAsync(user, "Admin");
                } else
                {
                    await _userManager.AddToRoleAsync(user, "Teacher");
                }
                await _userStore.SetUserNameAsync(user, userModel.UserName, CancellationToken.None);
                await _emailStore.SetEmailAsync(user, userModel.Email, CancellationToken.None);
                var result = await _userManager.CreateAsync(user, userModel.Password);
                if(result.Succeeded)
                {
                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code));
                    await _userManager.ConfirmEmailAsync(user, code);
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View(userModel);
        }

        public async Task<IActionResult> Edit(string id)
        {
            TeacherIdentity user = await _userManager.FindByIdAsync(id);
            if (user == null) 
            {
                return NotFound();
            }
            EditUserModel model = new EditUserModel
            {
                Id = user.Id,
                Email = user.Email,
                Name= user.Name,
                SecondName = user.SecondName,
                Sirname = user.Sirname,
                PhoneNumber = user.PhoneNumber,
                Role = await _userManager.IsInRoleAsync(user, "Admin")? "Admin" : "Teacher"
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit (EditUserModel model)
        {
            if(ModelState.IsValid)
            {
                TeacherIdentity teacher = await _userManager.FindByIdAsync(model.Id);
                if (teacher != null)
                {
                    teacher.Name = model.Name;
                    teacher.PhoneNumber = model.PhoneNumber;
                    teacher.Sirname = model.Sirname;
                    teacher.SecondName = model.SecondName;
                    teacher.Email = model.Email;
                    if(await _userManager.IsInRoleAsync(teacher, "Admin"))
                    {
                        await _userManager.RemoveFromRoleAsync(teacher, "Admin");
                    }
                    if (await _userManager.IsInRoleAsync(teacher, "Teacher"))
                    {
                        await _userManager.RemoveFromRoleAsync(teacher, "Teacher");
                    }
                    if(model.Role != null)
                    {
                        await _userManager.AddToRoleAsync(teacher, model.Role);
                    }

                    var result = await _userManager.UpdateAsync(teacher);
                    if(result.Succeeded)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        foreach(var error in result.Errors)
                        {
                            ModelState.AddModelError(string.Empty, error.Description);
                        }
                    }
                }
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            TeacherIdentity user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                IdentityResult result = await _userManager.DeleteAsync(user);
            }
            return RedirectToAction("Index");
        }
        private IUserEmailStore<TeacherIdentity> GetEmailStore()
        {
            if (!_userManager.SupportsUserEmail)
            {
                throw new NotSupportedException("The default UI requires a user store with email support.");
            }
            return (IUserEmailStore<TeacherIdentity>)_userStore;
        }
    }
}

using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Threading;
using System.Net;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System.Web.Security;
using Lost.Service.Common;
using Lost.DAL.Models;
using Lost.UI.Models;
using Lost.Model.Common;
using Lost.DAL;

namespace Lost.UI.Controllers
{
    public class UserController : Controller
    {
        protected IUserService Service { get; private set; }
        protected IRedService RedService { get; private set; }
        public RoleManager<IdentityRole> RoleManager { get; private set; }
        protected UserManager<ApplicationUserEntity> UserManager { get; private set; }

        public UserController(IUserService service, IRedService redService, RoleManager<IdentityRole> roleManager)
        {
            Service = service;
            RedService = redService;
            RoleManager = roleManager;
            UserManager = new UserManager<ApplicationUserEntity>(new UserStore<ApplicationUserEntity>(new SearchContext()));
        }

        // GET: User
        
        public async Task<ActionResult> Index(ApplicationUserEntity user)
        {
            return View(await UserManager.Users.ToListAsync());
        }

        [AllowAnonymous]
        public async Task<ActionResult> Create()
        {
            ViewBag.RedCross = await RedService.GetAllAsync(null);
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(RegisterViewModel model, ApplicationUserModel user)
        {
            if (ModelState.IsValid)
            {
                //http://prntscr.com/9q077y
                user = new ApplicationUserModel { Id = user.Id, UserName=model.UserName, Email = model.Email, FirstName = model.FirstName, LastName = model.LastName, OIB = model.OIB, RedCrossId = model.RedCrossId };

                //Register new user: http://prntscr.com/9q0bo6
                await Service.RegisterUser(AutoMapper.Mapper.Map<IApplicationUser>(user), model.Password);

                return RedirectToAction("Index");

            }
            else
            {
                ViewBag.RedCross = await RedService.GetAllAsync(null);
                return View();
            }
        }

        public async Task<ActionResult> Edit(string userId)
        {
            if (userId == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var user = await UserManager.FindByIdAsync(userId);

            if (user == null) return HttpNotFound();

            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(ApplicationUserModel editUser, string userId, string roleId)
        {
            if (userId == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var user = await UserManager.FindByIdAsync(userId);
            user.UserName = editUser.UserName;
            if (ModelState.IsValid)
            {
                await UserManager.UpdateAsync(user);

                var rolesForUser = await UserManager.GetRolesAsync(userId);
                if (rolesForUser.Count() > 0)
                {
                    foreach (var item in rolesForUser)
                    {
                        var result = await UserManager.RemoveFromRoleAsync(userId, item);
                    }
                }

                if (!String.IsNullOrWhiteSpace(roleId))
                {
                    var role = await RoleManager.FindByIdAsync(roleId);

                    var result = await UserManager.AddToRoleAsync(userId, role.Name);
                    if (!result.Succeeded)
                    {
                        ModelState.AddModelError("", result.Errors.First().ToString());
                        return View();
                    }
                }
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        public async Task<ActionResult> Delete(string id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var user = await UserManager.FindByIdAsync(id);

            if (user == null) return HttpNotFound();

            return View(user);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteUser(string id)
        {
            var user = await UserManager.FindByIdAsync(id);
            await UserManager.DeleteAsync(user);
            return RedirectToAction("Index");
        }
    }
}
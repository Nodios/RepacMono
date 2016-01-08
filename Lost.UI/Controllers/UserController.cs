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

namespace Lost.UI.Controllers
{
    public class UserController : Controller
    {
        protected IUserService Service { get; private set; }
        protected IRedService RedService { get; private set; }
        public RoleManager<IdentityRole> RoleManager { get; private set; }
        protected UserManager<ApplicationUser> UserManager { get; private set; }

        public UserController(IUserService service, IRedService redService, RoleManager<IdentityRole> roleManager)
        {
            Service = service;
            RedService = redService;
            RoleManager = roleManager;
            UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new SearchContext()));
        }

        // GET: User
        public async Task<ActionResult> Index(ApplicationUserEntity user, int? id)
        {
            return View(await UserManager.Users.ToListAsync());
        }

        public async Task<ActionResult> Create()
        {
            ViewBag.RedCross = await RedService.GetAllAsync(null);
            //ViewBag.RoleId = await RoleManager.Roles.ToListAsync();
            ViewBag.RoleId = new SelectList(await RoleManager.Roles.ToListAsync(), "Id", "Name");
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Create(RegisterViewModel model, ApplicationUserModel user, string RoleId)
        {
            if (ModelState.IsValid)
            {
                user.PersonInCharge = new PersonInChargeModel { FirstName=model.FirstName, LastName = model.LastName, OIB=model.OIB, RedCrossId = model.RedCrossId };

                //Register new user
                bool adminResult = await Service.RegisterUser(AutoMapper.Mapper.Map<IApplicationUser>(user), model.Password);

                if (adminResult)
                {
                    if (!String.IsNullOrWhiteSpace(RoleId))
                    {
                        var role = await RoleManager.FindByIdAsync(RoleId);
                        var result = await UserManager.AddToRoleAsync(user.Id, role.Name);
                        if (!result.Succeeded)
                        {
                            ModelState.AddModelError("", result.Errors.First().ToString());
                            ViewBag.RedCross = await RedService.GetAllAsync(null);
                            //ViewBag.RoleId = await RoleManager.Roles.ToListAsync();
                            ViewBag.RoleId = new SelectList(await RoleManager.Roles.ToListAsync(), "Id", "Name");
                            return View();
                        }
                    }
                }
                else
                {
                    ViewBag.RedCross = await RedService.GetAllAsync(null);
                    //ViewBag.RoleId = await RoleManager.Roles.ToListAsync();
                    ViewBag.RoleId = new SelectList(await RoleManager.Roles.ToListAsync(), "Id", "Name");
                    return View();
                }
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.RedCross = await RedService.GetAllAsync(null);
                //ViewBag.RoleId = await RoleManager.Roles.ToListAsync();
                ViewBag.RoleId = new SelectList(await RoleManager.Roles.ToListAsync(), "Id", "Name");
                return View();
            }
        }

        public async Task<ActionResult> Edit(string id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            //ViewBag.RoleId = await RoleManager.Roles.ToListAsync();
            ViewBag.RoleId = new SelectList(await RoleManager.Roles.ToListAsync(), "Id", "Name");
            var user = await UserManager.FindByIdAsync(id);

            if (user == null) return HttpNotFound();

            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(ApplicationUser editUser, string id, string RoleId)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            ViewBag.RoleId = await RoleManager.Roles.ToListAsync();
            var user = await UserManager.FindByIdAsync(id);
            user.UserName = editUser.UserName;
            if (ModelState.IsValid)
            {
                await UserManager.UpdateAsync(user);

                var rolesForUser = await UserManager.GetRolesAsync(id);
                if (rolesForUser.Count() > 0)
                {
                    foreach (var item in rolesForUser)
                    {
                        var result = await UserManager.RemoveFromRoleAsync(id, item);
                    }
                }

                if (!String.IsNullOrWhiteSpace(RoleId))
                {
                    var role = await RoleManager.FindByIdAsync(RoleId);

                    var result = await UserManager.AddToRoleAsync(id, role.Name);
                    if (!result.Succeeded)
                    {
                        ModelState.AddModelError("", result.Errors.First().ToString());
                        ViewBag.RoleId = await RoleManager.Roles.ToListAsync();
                        return View();
                    }
                }
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.RoleId = new SelectList(await RoleManager.Roles.ToListAsync(), "Id", "Name");
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
        public async Task<ActionResult> DeletePost(string id)
        {
            var user = await UserManager.FindByIdAsync(id);
            await UserManager.DeleteAsync(user);
            return RedirectToAction("Index");
        }
    }
}
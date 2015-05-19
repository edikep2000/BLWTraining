using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLWTraining.Models;
using Microsoft.AspNet.Identity;
using Omu.AwesomeMvc;

namespace BlwTraining.Controllers.ListControllers
{
    public class UserMultiLookupController : Controller
    {
        private readonly IQueryableUserStore<IdentityUser, Int32> _userStore;

        public UserMultiLookupController(IQueryableUserStore<IdentityUser, int> userStore)
        {
            _userStore = userStore;
        }
        public ActionResult SearchForm()
        {
            return View("UserSearchForm");
        }
        public ActionResult GetItems(int[] v)
        {
         var s =   _userStore.Users.Where(i => v != null && v.Contains(i.Id)).Select(
                f => new KeyContent(f.Id, f.LastName + " " + f.FirstName + "(" + f.Zone1.Name + ")"));
            return Json(s);
        }
        public ActionResult Selected(int[] selected)
        {
            return Json(new AjaxListResult
            {
                Items = _userStore.Users.Where(i => selected != null && selected.Contains(i.Id))
                    .Select(f => new KeyContent(f.Id, f.LastName + " " + f.FirstName + "(" + f.Zone1.Name + ")"))

            });
        }
        public ActionResult Search(string search, int[] selected, int[] zones, string emailAddress, int page)
        {
            const int PageSize = 10;
            selected = selected ?? new int[] {};
            search = (search ?? "").ToLower().Trim();
            zones = zones ?? new int[] {};
            emailAddress = (emailAddress ?? "").ToLower().Trim();

            var items =
                _userStore.Users.Where(
                    i =>
                        (i.LastName.ToLower().Contains(search) || i.FirstName.ToLower().Contains(search) ||
                         i.EmailAddress.Contains(emailAddress)) && (!selected.Contains(i.Id))
                        && (i.Zone != 0 && zones.Contains(i.Zone) || zones.Count() == 0));

            return Json(new AjaxListResult()
            {
                Items = items.OrderBy(i => i.Id).Skip((page - 1)*PageSize).Take(PageSize)
                    .Select(f => new KeyContent(f.Id, f.LastName + " " + f.FirstName + "(" + f.Zone1.Name + ")")),
                More = items.Count() > page*PageSize
            });

        }
    }
}
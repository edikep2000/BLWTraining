using System.Linq;
using System.Web.Mvc;
using BLWTraining.Models;
using Microsoft.AspNet.Identity;
using Omu.AwesomeMvc;

namespace BlwTraining.Controllers.ListControllers
{
    public class UserLookupController : Controller
    {
        private readonly IQueryableUserStore<IdentityUser, int> _userStore;
        public UserLookupController(IQueryableUserStore<IdentityUser, int> userStore)
        {
            _userStore = userStore;
        }
        public ActionResult SearchForm()
        {
            return View("UserSearchForm");
        }
        public ActionResult GetItems(int? v)
        {
            var s = _userStore.Users.SingleOrDefault(f => f.Id == v) ?? new IdentityUser();
            return Json(new KeyContent(s.Id, s.LastName + " " + s.FirstName + "(" + s.Zone1.Name + ")"));
        }
        public ActionResult Search(string search,  int[] zones, string emailAddress, int page)
        {
            const int PageSize = 10;
            search = (search ?? "").ToLower().Trim();
            zones = zones ?? new int[] {};
            emailAddress = (emailAddress ?? "").ToLower().Trim();

            var items =
                _userStore.Users.Where(
                    i =>
                        (i.LastName.ToLower().Contains(search) || i.FirstName.ToLower().Contains(search) ||
                         i.EmailAddress.Contains(emailAddress))
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
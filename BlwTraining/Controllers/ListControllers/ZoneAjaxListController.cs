using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLWTraining.DataAccess.Service;
using Omu.AwesomeMvc;

namespace BlwTraining.Controllers.ListControllers
{
    public class ZoneAjaxListController : Controller
    {
        private readonly ZoneStore _zoneStore;
        public ZoneAjaxListController(ZoneStore zoneStore)
        {
            _zoneStore = zoneStore;
        }
        // GET: ZoneAjaxList
        public ActionResult GetList(int? v)
        {
            var zones = _zoneStore.GetAll().Select(i => new SelectableItem
            {
                Selected = v == i.Id,
                Text = i.Name,
                Value = i.Id
            }).ToList();
            return Json(zones);
        }
    }
}
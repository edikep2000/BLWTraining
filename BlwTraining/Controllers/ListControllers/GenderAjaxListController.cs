using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLWTraning.Common.Enums;
using Omu.AwesomeMvc;

namespace BlwTraining.Controllers.ListControllers
{
    public class GenderAjaxListController : Controller
    {
        // GET: GenderAjaxList
        public ActionResult GetList(string v)
        {
            var list = Enum.GetNames(typeof (GenderEnum)).Select(i => new SelectableItem
            {
                Selected = v == i,
                Text = i,
                Value = i
            }).ToList();
            return Json(list);
        }
    }
}
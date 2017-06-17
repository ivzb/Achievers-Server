using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Mine360.Data.Common;
using Mine360.Data.Models;
using Mine360.Services.Data;
using Mine360.Web.Infrastructure.Mapping;
using Mine360.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Mine360.Web.Controllers
{
    public class RepairRequestsController : BaseController
    {
        private readonly RepairRequestsService service;

        public RepairRequestsController(IDbRepository<RepairRequest> repo)
        {
            this.service = new RepairRequestsService(repo);
        }
        // GET: RepairRequests
        public ActionResult GetsRepairRequestsForEquipment([DataSourceRequest] DataSourceRequest request, int equipmentId)
        {
            var data = this.service.Get().To<RepairRequestViewModel>().Where(a => a.Equipment.Id == equipmentId);
            DataSourceResult dataSourceResult = data.ToDataSourceResult(request);
            return Json(dataSourceResult);
        }
    }
}
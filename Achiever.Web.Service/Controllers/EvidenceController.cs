namespace Achiever.Web.Service.Controllers
{
    using Achiever.Data.Models;
    using Achiever.Services.Data.Interfaces;
    using Base;
    using System.Web.Http;
    using System.Web.Http.OData;

    //[Authorize]
    public class EvidenceController : BaseController
    {
        private IDefaultService<Evidence> service;

        public EvidenceController(IDefaultService<Evidence> service)
        {
            this.service = service;
        }

        // GET: odata/Evidence(5)
        [EnableQuery]
        public Evidence GetEvidence([FromODataUri] int key)
        {
            return this.service.Get(key);
        }
    }
}
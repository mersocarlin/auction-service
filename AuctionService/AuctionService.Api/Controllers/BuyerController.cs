using AuctionService.Domain.Contracts.Services;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace AuctionService.Api.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/v1/buyer")]
    public class BuyerController : ApiController
    {
        private IBuyerService _service;

        public BuyerController(IBuyerService service)
        {
            this._service = service;
        }

        [HttpGet]
        [Route("")]
        public Task<HttpResponseMessage> GetBuyers()
        {
            HttpResponseMessage response = new HttpResponseMessage();

            try
            {
                var result = _service.Get();
                response = Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }

            var tsc = new TaskCompletionSource<HttpResponseMessage>();
            tsc.SetResult(response);
            return tsc.Task;
        }
    }
}

using AuctionService.Domain.Contracts.Services;
using AuctionService.Domain.Models;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace AuctionService.Api.Controllers
{
    [RoutePrefix("api/v1/auction")]
    public class AuctionController : ApiController
    {
        private IAuctionService _service;

        public AuctionController(IAuctionService service)
        {
            this._service = service;
        }

        [HttpGet]
        [Route("")]
        public Task<HttpResponseMessage> GetAuctions()
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

        [HttpGet]
        [Route("{id}")]
        public Task<HttpResponseMessage> GetAuctionById(int id)
        {
            HttpResponseMessage response = new HttpResponseMessage();

            try
            {
                var result = _service.GetById(id);
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

        [HttpPost]
        [Route("")]
        public Task<HttpResponseMessage> PostAuction(Auction auction)
        {
            HttpResponseMessage response = new HttpResponseMessage();

            try
            {
                _service.Save(auction);
                response = Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }

            var tsc = new TaskCompletionSource<HttpResponseMessage>();
            tsc.SetResult(response);
            return tsc.Task;
        }

        [HttpPost]
        [Route("bid/{auctionId}/{buyerId}")]
        public Task<HttpResponseMessage> PlaceBid(int auctionId, int buyerId)
        {
            HttpResponseMessage response = new HttpResponseMessage();

            try
            {
                var result = _service.PlaceBid(auctionId, buyerId);
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

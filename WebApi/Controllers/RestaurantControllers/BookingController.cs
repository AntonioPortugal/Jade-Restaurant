using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RECODME.RD.Jade.Business.BusinessObjects.RestaurantBusinessObjects;
using RECODME.RD.Jade.Data.RestaurantInfo;
using RECODME.RD.Jade.WebApi.Models.RestaurantModelViews;

namespace RECODME.RD.Jade.WebApi.Controllers.RestaurantControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private BookingBusinessObject _bo = new BookingBusinessObject();

        [HttpPost]
        public ActionResult Create([FromBody]BookingViewModel vm)
        {
            var bk = vm.ToBooking();
            var res = _bo.Create(bk);
            return new ObjectResult(res.Success ? HttpStatusCode.OK : HttpStatusCode.InternalServerError);
        }

        [HttpGet("{id}")]
        public ActionResult<BookingViewModel> Get(Guid id)
        {
            var res = _bo.Read(id);
            if (res.Success)
            {
                if (res.Result == null) return NotFound();
                var vm = BookingViewModel.Parse(res.Result);
                return vm;
            }
            else return new ObjectResult(HttpStatusCode.InternalServerError);
        }

        [HttpGet]
        public ActionResult<List<BookingViewModel>> List()
        {
            var res = _bo.List();
            if (!res.Success) return new ObjectResult(HttpStatusCode.InternalServerError);
            var list = new List<BookingViewModel>();
            foreach (var item in res.Result)
            {
                list.Add(BookingViewModel.Parse(item));
            }
            return list;
        }

        [HttpPut]
        public ActionResult Update([FromBody]BookingViewModel bk)
        {
            var currentResult = _bo.Read(bk.Id);
            if (!currentResult.Success) return new ObjectResult(HttpStatusCode.InternalServerError);
            var current = currentResult.Result;
            if (current == null) return NotFound();

            if (current.Date == bk.Date) return new ObjectResult(HttpStatusCode.NotModified);

            if (current.Date != bk.Date) current.Date = bk.Date;

            var updateResult = _bo.Update(current);
            if (!updateResult.Success) return new ObjectResult(HttpStatusCode.InternalServerError);
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            var result = _bo.Delete(id);
            if (result.Success) return Ok();
            return new ObjectResult(HttpStatusCode.InternalServerError);
        }
    }
}
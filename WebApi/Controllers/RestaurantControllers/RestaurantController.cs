using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RECODME.RD.Jade.Business.BusinessObjects.RestaurantBusinessObjects;
using RECODME.RD.Jade.Data.RestaurantInfo;
using WebApi.Models.RestaurantModelViews;

namespace WebApi.Controllers.RestaurantControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private RestaurantBusinessObject _bo = new RestaurantBusinessObject();

        [HttpPost]
        public ActionResult Create([FromBody]RestaurantViewModel vm)
        {
            var rt = vm.ToRestaurant();
            var res = _bo.Create(rt);
            return new ObjectResult(res.Success ? HttpStatusCode.OK : HttpStatusCode.InternalServerError);
        }

        [HttpGet("{id}")]
        public ActionResult<RestaurantViewModel> Get(Guid id)
        {
            var res = _bo.Read(id);
            if (res.Success)
            {
                if (res.Result == null) return NotFound();
                var vm = RestaurantViewModel.Parse(res.Result);
                return vm;
            }
            else return new ObjectResult(HttpStatusCode.InternalServerError);
        }

        [HttpGet]
        public ActionResult<List<RestaurantViewModel>> List()
        {
            var res = _bo.List();
            if (!res.Success) return new ObjectResult(HttpStatusCode.InternalServerError);
            var list = new List<RestaurantViewModel>();
            foreach (var item in res.Result)
            {
                list.Add(RestaurantViewModel.Parse(item));
            }
            return list;
        }

        [HttpPut]
        public ActionResult Update([FromBody]RestaurantViewModel rt)
        {
            var currentResult = _bo.Read(rt.Id);
            if (!currentResult.Success) return new ObjectResult(HttpStatusCode.InternalServerError);
            var current = currentResult.Result;
            if (current == null) return NotFound();

            if (current.Name == rt.Name && current.Address == rt.Address && current.OpeningHours == rt.OpeningHours && current.ClosingHours == rt.ClosingHours && current.ClosingDays == rt.ClosingDays && current.TableCount == rt.TableCount) return new ObjectResult(HttpStatusCode.NotModified);

            if (current.Name != rt.Name) current.Name = rt.Name;
            if (current.Address != rt.Address) current.Address = rt.Address;
            if (current.OpeningHours != rt.OpeningHours) current.OpeningHours = rt.OpeningHours;
            if (current.ClosingHours != rt.ClosingHours) current.ClosingHours = rt.ClosingHours;
            if (current.ClosingDays != rt.ClosingDays) current.ClosingDays = rt.ClosingDays;
            if (current.TableCount != rt.TableCount) current.TableCount = rt.TableCount;

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
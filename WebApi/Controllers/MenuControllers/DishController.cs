using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RECODME.RD.Jade.Business.BusinessObjects.MenuBusinessObjects;
using RECODME.RD.Jade.WebApi.Models.MenuModelViews;
using RECODME.RD.Jade.WebApi.Models.RestaurantModelViews;

namespace RECODME.RD.Jade.WebApi.Controllers.MenuControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DishController : ControllerBase
    {
        private DishBusinessObject _bo = new DishBusinessObject();

        [HttpPost]
        public ActionResult Create([FromBody]DishViewModel vm)
        {
            var ds = vm.ToDish();
            var res = _bo.Create(ds);

            return new ObjectResult(res.Success ? HttpStatusCode.OK : HttpStatusCode.InternalServerError);
        }

        [HttpGet("{id}")]
        public ActionResult<DishViewModel> Get(Guid id)
        {
            var res = _bo.Read(id);
            if (res.Success)
            {
                if (res.Result == null) return NotFound();

                var vm = DishViewModel.Parse(res.Result);
                return vm;
            }
            else return new ObjectResult(HttpStatusCode.InternalServerError);
        }

        [HttpGet]
        public ActionResult<List<DishViewModel>> List()
        {
            var res = _bo.List();
            if (!res.Success) return new ObjectResult(HttpStatusCode.InternalServerError);

            var list = new List<DishViewModel>();
            foreach (var item in res.Result)
            {
                list.Add(DishViewModel.Parse(item));
            }

            return list;
        }

        [HttpPut]
        public ActionResult Update([FromBody]DishViewModel ds)
        {
            var currentResult = _bo.Read(ds.Id);
            if (!currentResult.Success) return new ObjectResult(HttpStatusCode.InternalServerError);

            var current = currentResult.Result;
            if (current == null) return NotFound();

            if (current.Name == ds.Name) return new ObjectResult(HttpStatusCode.NotModified);

            if (current.Name != ds.Name) current.Name = ds.Name;

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
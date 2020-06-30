using Microsoft.AspNetCore.Mvc;
using RECODME.RD.Jade.Business.BusinessObjects.MenuBusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using RECODME.RD.Jade.WebApi.Models.MenuModelViews;

namespace RECODME.RD.Jade.WebApi.Controllers.MenuControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DietaryRestrictionController : ControllerBase
    {
        private DietaryRestrictionBusinessObject _bo = new DietaryRestrictionBusinessObject();

        [HttpPost]
        public ActionResult Create([FromBody]DietaryRestrictionViewModel vm)
        {
            var dr = vm.ToDietaryRestriction();
            var res = _bo.Create(dr);

            return new ObjectResult(res.Success ? HttpStatusCode.OK : HttpStatusCode.InternalServerError);
        }

        [HttpGet("{id}")]
        public ActionResult<DietaryRestrictionViewModel> Get(Guid id)
        {
            var res = _bo.Read(id);
            if (res.Success)
            {
                if (res.Result == null) return NotFound();

                var vm = DietaryRestrictionViewModel.Parse(res.Result);
                return vm;
            }
            else return new ObjectResult(HttpStatusCode.InternalServerError);
        }

        [HttpGet]
        public ActionResult<List<DietaryRestrictionViewModel>> List()
        {
            var res = _bo.List();
            if (!res.Success) return new ObjectResult(HttpStatusCode.InternalServerError);

            var list = new List<DietaryRestrictionViewModel>();
            foreach (var item in res.Result)
            {
                list.Add(DietaryRestrictionViewModel.Parse(item));
            }

            return list;
        }

        [HttpPut]
        public ActionResult Update([FromBody]DietaryRestrictionViewModel dr)
        {
            var currentResult = _bo.Read(dr.Id);
            if (!currentResult.Success) return new ObjectResult(HttpStatusCode.InternalServerError);

            var current = currentResult.Result;
            if (current == null) return NotFound();

            if (current.Name == dr.Name) return new ObjectResult(HttpStatusCode.NotModified);

            if (current.Name != dr.Name) current.Name = dr.Name;

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
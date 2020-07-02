using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using RECODME.RD.Jade.Business.BusinessObjects.MenuBusinessObjects;
using RECODME.RD.Jade.WebApi.Models.MenuModelViews;

namespace RECODME.RD.Jade.WebApi.Controllers.MenuControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DishController : BaseController
    {
        private DishBusinessObject _bo = new DishBusinessObject();

        [HttpPost]
        public ActionResult Create([FromBody]DishViewModel vm)
        {
            var ds = vm.ToDish();
            var res = _bo.Create(ds);

            return (res.Success ? Ok() : InternalServerError());
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
            else return InternalServerError();
        }

        [HttpGet]
        public ActionResult<List<DishViewModel>> List()
        {
            var res = _bo.List();
            if (!res.Success) return InternalServerError();

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
            if (!currentResult.Success) return InternalServerError();

            var current = currentResult.Result;
            if (current == null) return NotFound();

            if (current.Name == ds.Name) return NotModified();

            if (current.Name != ds.Name) current.Name = ds.Name;

            var updateResult = _bo.Update(current);
            if (!updateResult.Success) return InternalServerError();

            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            var result = _bo.Delete(id);
            if (result.Success) return Ok();

            return InternalServerError();
        }
    }
}
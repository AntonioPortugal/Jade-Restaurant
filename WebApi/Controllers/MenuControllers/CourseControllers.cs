using Microsoft.AspNetCore.Mvc;
using RECODME.RD.Jade.Business.BusinessObjects.MenuBusinessObjects;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using RECODME.RD.Jade.WebApi.Models.MenuModelViews;
using RECODME.RD.Jade.WebApi.WebApi.Controllers;

namespace RECODME.RD.Jade.WebApi.Controllers.MenuControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseControllers : BaseController
    {
        private CourseBusinessObject _bo = new CourseBusinessObject();

        [HttpPost]
        public ActionResult Create([FromBody]CourseViewModel vm)
        {
            var rt = vm.ToCourse();
            var res = _bo.Create(rt);
            return (res.Success ? Ok() : InternalServerError());
        }

        [HttpGet("{id}")]
        public ActionResult<CourseViewModel> Get(Guid id)
        {
            var res = _bo.Read(id);
            if (res.Success)
            {
                if (res.Result == null) return NotFound();
                var vm = CourseViewModel.Parse(res.Result);
                return vm;
            }
            else return InternalServerError();
        }

        [HttpGet]
        public ActionResult<List<CourseViewModel>> List()
        {
            var res = _bo.List();
            if (!res.Success) return InternalServerError();
            var list = new List<CourseViewModel>();
            foreach (var item in res.Result)
            {
                list.Add(CourseViewModel.Parse(item));
            }
            return list;
        }

        [HttpPut]
        public ActionResult Update([FromBody]CourseViewModel ds)
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

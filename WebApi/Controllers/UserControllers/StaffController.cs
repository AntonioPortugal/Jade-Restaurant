using Microsoft.AspNetCore.Mvc;
using RECODME.RD.Jade.Business.BusinessObjects.UserBusinessObjects;
using System;
using System.Collections.Generic;
using System.Net;
using RECODME.RD.Jade.WebApi.Models.UserModelViews;
using RECODME.RD.Jade.WebApi.Controllers;

namespace RECODME.RD.Jade.WebApi.Controllers.UserControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : BaseController
    {
        private StaffBusinessObject _bo = new StaffBusinessObject();

        [HttpPost]
        public ActionResult Create([FromBody]StaffViewModel vm)
        {
            var rt = vm.ToStaff();
            var res = _bo.Create(rt);
            return (res.Success ? Ok() : InternalServerError());
        }

        [HttpGet("{id}")]
        public ActionResult<StaffViewModel> Get(Guid id)
        {
            var res = _bo.Read(id);
            if (res.Success)
            {
                if (res.Result == null) return NotFound();
                var vm = StaffViewModel.Parse(res.Result);
                return vm;
            }
            else return InternalServerError();
        }

        [HttpGet]
        public ActionResult<List<StaffViewModel>> List()
        {
            var res = _bo.List();
            if (!res.Success) return InternalServerError();
            var list = new List<StaffViewModel>();
            foreach (var item in res.Result)
            {
                list.Add(StaffViewModel.Parse(item));
            }
            return list;
        }

        [HttpPut]
        public ActionResult Update([FromBody]StaffViewModel rt)
        {
            var currentResult = _bo.Read(rt.Id);
            if (!currentResult.Success) return InternalServerError();
            var current = currentResult.Result;
            if (current == null) return NotFound();

            if (current.BeginDate == rt.BeginDate && current.EndDate == rt.EndDate) return InternalServerError();

            if (current.BeginDate != rt.BeginDate) current.BeginDate = rt.BeginDate;
            if (current.EndDate != rt.EndDate) current.EndDate = rt.EndDate;

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

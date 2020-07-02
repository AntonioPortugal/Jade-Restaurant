using Microsoft.AspNetCore.Mvc;
using RECODME.RD.Jade.Business.BusinessObjects.UserBusinessObjects;
using System;
using System.Collections.Generic;
using System.Net;
using RECODME.RD.Jade.WebApi.Models.UserModelViews;
using WebApi.Controllers;

namespace RECODME.RD.Jade.WebApi.Controllers.UserControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientRecordController : BaseController
    {
        private ClientBusinessObject _bo = new ClientBusinessObject();

        [HttpPost]
        public ActionResult Create([FromBody]ClientViewModel vm)
        {
            var rt = vm.ToClient();
            var res = _bo.Create(rt);
            return (res.Success ? Ok() : InternalServerError());
        }

        [HttpGet("{id}")]
        public ActionResult<ClientViewModel> Get(Guid id)
        {
            var res = _bo.Read(id);
            if (res.Success)
            {
                if (res.Result == null) return NotFound();
                var vm = ClientViewModel.Parse(res.Result);
                return vm;
            }
            else return InternalServerError();
        }

        [HttpGet]
        public ActionResult<List<ClientViewModel>> List()
        {
            var res = _bo.List();
            if (!res.Success) return InternalServerError();
            var list = new List<ClientViewModel>();
            foreach (var item in res.Result)
            {
                list.Add(ClientViewModel.Parse(item));
            }
            return list;
        }

        [HttpPut]
        public ActionResult Update([FromBody]ClientViewModel rt)
        {
            var currentResult = _bo.Read(rt.Id);
            if (!currentResult.Success) return InternalServerError();
            var current = currentResult.Result;
            if (current == null) return NotFound();

            if (current.RegisterDate == rt.RegisterDate) return NotModified();

            if (current.RegisterDate != rt.RegisterDate) current.RegisterDate = rt.RegisterDate;

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

using Microsoft.AspNetCore.Mvc;
using RECODME.RD.Jade.Business.BusinessObjects.UserBusinessObjects;
using System;
using System.Collections.Generic;
using System.Net;
using WebApi.Models.UserModelViews;

namespace WebApi.Controllers.UserControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientRecordController : ControllerBase
    {
        private ClientBusinessObject _bo = new ClientBusinessObject();

        [HttpPost]
        public ActionResult Create([FromBody]ClientViewModel vm)
        {
            var rt = vm.ToClient();
            var res = _bo.Create(rt);
            return new ObjectResult(res.Success ? HttpStatusCode.OK : HttpStatusCode.InternalServerError);
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
            else return new ObjectResult(HttpStatusCode.InternalServerError);
        }

        [HttpGet]
        public ActionResult<List<ClientViewModel>> List()
        {
            var res = _bo.List();
            if (!res.Success) return new ObjectResult(HttpStatusCode.InternalServerError);
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
            if (!currentResult.Success) return new ObjectResult(HttpStatusCode.InternalServerError);
            var current = currentResult.Result;
            if (current == null) return NotFound();

            if (current.RegisterDate == rt.RegisterDate) return new ObjectResult(HttpStatusCode.NotModified);

            if (current.RegisterDate != rt.RegisterDate) current.RegisterDate = rt.RegisterDate;

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

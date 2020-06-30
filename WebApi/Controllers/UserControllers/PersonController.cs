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
    public class PersonController : ControllerBase
    {
        private PersonBusinessObject _bo = new PersonBusinessObject();

        [HttpPost]
        public ActionResult Create([FromBody]PersonViewModel vm)
        {
            var rt = vm.ToPerson();
            var res = _bo.Create(rt);
            return new ObjectResult(res.Success ? HttpStatusCode.OK : HttpStatusCode.InternalServerError);
        }

        [HttpGet("{id}")]
        public ActionResult<PersonViewModel> Get(Guid id)
        {
            var res = _bo.Read(id);
            if (res.Success)
            {
                if (res.Result == null) return NotFound();
                var vm = PersonViewModel.Parse(res.Result);
                return vm;
            }
            else return new ObjectResult(HttpStatusCode.InternalServerError);
        }

        [HttpGet]
        public ActionResult<List<PersonViewModel>> List()
        {
            var res = _bo.List();
            if (!res.Success) return new ObjectResult(HttpStatusCode.InternalServerError);
            var list = new List<PersonViewModel>();
            foreach (var item in res.Result)
            {
                list.Add(PersonViewModel.Parse(item));
            }
            return list;
        }

        [HttpPut]
        public ActionResult Update([FromBody]PersonViewModel rt)
        {
            var currentResult = _bo.Read(rt.Id);
            if (!currentResult.Success) return new ObjectResult(HttpStatusCode.InternalServerError);
            var current = currentResult.Result;
            if (current == null) return NotFound();

            if (current.VatNumber == rt.VATNumber && current.FirstName == rt.FirstName && current.LastName == rt.LastName && current.PhoneNumber == rt.PhoneNumber && current.BirthDate == rt.Birthdate) return new ObjectResult(HttpStatusCode.NotModified);

            if (current.VatNumber != rt.VATNumber) current.VatNumber = rt.VATNumber;
            if (current.FirstName != rt.FirstName) current.FirstName = rt.FirstName;
            if (current.LastName != rt.LastName) current.LastName = rt.LastName;
            if (current.PhoneNumber != rt.PhoneNumber) current.PhoneNumber = rt.PhoneNumber;
            if (current.BirthDate != rt.Birthdate) current.BirthDate = rt.Birthdate;

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

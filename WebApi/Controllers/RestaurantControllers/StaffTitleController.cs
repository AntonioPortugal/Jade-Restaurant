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

namespace WebApi.Controllers.StaffTitleControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffTitleController : ControllerBase
    {
        private StaffTitleBusinessObject _bo = new StaffTitleBusinessObject();

        [HttpPost]
        public ActionResult Create([FromBody]StaffTitleViewModel vm)
        {
            var st = new StaffTitle(vm.Id, DateTime.Now, DateTime.Now, false, vm.StartDate, vm.EndDate, vm.TitleId, vm.StaffRecordId);
            var res = _bo.Create(st);
            return new ObjectResult(res.Success ? HttpStatusCode.OK : HttpStatusCode.InternalServerError);
        }

        [HttpGet("{id}")]
        public ActionResult<StaffTitleViewModel> Get(Guid id)
        {
            var res = _bo.Read(id);
            if (res.Success)
            {
                if (res.Result == null) return NotFound();
                var vm = StaffTitleViewModel.Parse(res.Result);
                return vm;
            }
            else return new ObjectResult(HttpStatusCode.InternalServerError);
        }

        [HttpGet]
        public ActionResult<List<StaffTitleViewModel>> List()
        {
            var res = _bo.List();
            if (!res.Success) return new ObjectResult(HttpStatusCode.InternalServerError);
            var list = new List<StaffTitleViewModel>();
            foreach (var item in res.Result)
            {
                list.Add(StaffTitleViewModel.Parse(item));
            }
            return list;
        }

        [HttpPut]
        public ActionResult Update([FromBody]StaffTitleViewModel st)
        {
            var currentResult = _bo.Read(st.Id);
            if (!currentResult.Success) return new ObjectResult(HttpStatusCode.InternalServerError);
            var current = currentResult.Result;
            if (current == null) return NotFound();

            if (current.StartDate == st.StartDate && current.EndDate == st.EndDate) return new ObjectResult(HttpStatusCode.NotModified);

            if (current.StartDate != st.StartDate) current.StartDate = st.StartDate;
            if (current.EndDate != st.EndDate) current.EndDate = st.EndDate;
            if (current.TitleId != st.TitleId) current.TitleId = st.TitleId;
            if (current.StaffRecordId != st.StaffRecordId) current.StaffRecordId = st.StaffRecordId;

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
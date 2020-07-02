using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RECODME.RD.Jade.Business.BusinessObjects.RestaurantBusinessObjects;
using RECODME.RD.Jade.Data.RestaurantInfo;
using RECODME.RD.Jade.WebApi.Models.RestaurantModelViews;

namespace RECODME.RD.Jade.WebApi.Controllers.StaffTitleControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffTitleController : BaseController
    {
        private StaffTitleBusinessObject _bo = new StaffTitleBusinessObject();

        [HttpPost]
        public ActionResult Create([FromBody]StaffTitleViewModel vm)
        {
            var st = vm.ToStaffTitle();
            var res = _bo.Create(st);
            return (res.Success ? Ok() :InternalServerError());
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
            else return InternalServerError();
        }

        [HttpGet]
        public ActionResult<List<StaffTitleViewModel>> List()
        {
            var res = _bo.List();
            if (!res.Success) return InternalServerError();
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
            if (!currentResult.Success) return InternalServerError();
            var current = currentResult.Result;
            if (current == null) return NotFound();

            if (current.StartDate == st.StartDate && current.EndDate == st.EndDate) return NotModified();

            if (current.StartDate != st.StartDate) current.StartDate = st.StartDate;
            if (current.EndDate != st.EndDate) current.EndDate = st.EndDate;
            if (current.TitleId != st.TitleId) current.TitleId = st.TitleId;
            if (current.StaffRecordId != st.StaffRecordId) current.StaffRecordId = st.StaffRecordId;

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
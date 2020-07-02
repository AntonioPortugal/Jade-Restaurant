using Microsoft.AspNetCore.Mvc;
using RECODME.RD.Jade.Business.BusinessObjects.MenuBusinessObjects;
using System;
using System.Collections.Generic;
using RECODME.RD.Jade.WebApi.Models.MenuModelViews;

namespace RECODME.RD.Jade.WebApi.Controllers.MenuControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MealController : BaseController
    {
        private MealBusinessObject _bo = new MealBusinessObject();

        [HttpPost]
        public ActionResult Create([FromBody]MealViewModel vm)
        {
            var ml = vm.ToMeal();
            var res = _bo.Create(ml);

            return (res.Success ? Ok() : InternalServerError());
        }

        [HttpGet("{id}")]
        public ActionResult<MealViewModel> Get(Guid id)
        {
            var res = _bo.Read(id);
            if (res.Success)
            {
                if (res.Result == null) return NotFound();

                var vm = MealViewModel.Parse(res.Result);
                return vm;
            }
            else return InternalServerError();
        }

        [HttpGet]
        public ActionResult<List<MealViewModel>> List()
        {
            var res = _bo.List();
            if (!res.Success) return InternalServerError();

            var list = new List<MealViewModel>();
            foreach (var item in res.Result)
            {
                list.Add(MealViewModel.Parse(item));
            }

            return list;
        }

        [HttpPut]
        public ActionResult Update([FromBody]MealViewModel ml)
        {
            var currentResult = _bo.Read(ml.Id);
            if (!currentResult.Success) return InternalServerError();

            var current = currentResult.Result;
            if (current == null) return NotFound();

            if (current.Name == ml.Name && current.StartingHours == ml.StartingHours && current.EndingHours == ml.EndingHours) return NotModified();

            if (current.Name != ml.Name) current.Name = ml.Name;
            if (current.StartingHours != ml.StartingHours) current.StartingHours = ml.StartingHours;
            if (current.EndingHours != ml.EndingHours) current.EndingHours = ml.EndingHours;

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
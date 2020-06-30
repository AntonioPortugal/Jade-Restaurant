﻿using Microsoft.AspNetCore.Mvc;
using RECODME.RD.Jade.Business.BusinessObjects.MenuBusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using WebApi.Models.MenuModelViews;

namespace WebApi.Controllers.MenuControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MealController : ControllerBase
    {
        private MealBusinessObject _bo = new MealBusinessObject();

        [HttpPost]
        public ActionResult Create([FromBody]MealViewModel vm)
        {
            var ml = vm.ToMeal();
            var res = _bo.Create(ml);

            return new ObjectResult(res.Success ? HttpStatusCode.OK : HttpStatusCode.InternalServerError);
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
            else return new ObjectResult(HttpStatusCode.InternalServerError);
        }

        [HttpGet]
        public ActionResult<List<MealViewModel>> List()
        {
            var res = _bo.List();
            if (!res.Success) return new ObjectResult(HttpStatusCode.InternalServerError);

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
            if (!currentResult.Success) return new ObjectResult(HttpStatusCode.InternalServerError);

            var current = currentResult.Result;
            if (current == null) return NotFound();

            if (current.Name == ml.Name && current.StartingHours == ml.StartingHours && current.EndingHours == ml.EndingHours) return new ObjectResult(HttpStatusCode.NotModified);

            if (current.Name != ml.Name) current.Name = ml.Name;
            if (current.StartingHours != ml.StartingHours) current.StartingHours = ml.StartingHours;
            if (current.EndingHours != ml.EndingHours) current.EndingHours = ml.EndingHours;

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
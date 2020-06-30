using Microsoft.AspNetCore.Mvc;
using RECODME.RD.Jade.Business.BusinessObjects.MenuBusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using WebApi.Models.MenuViewModel;

namespace WebApi.Controllers.MenuControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuControllers : ControllerBase
    {
        private MenuBusinessObject _bo = new MenuBusinessObject();


        [HttpPost]
        public ActionResult Create([FromBody]MenuViewModel vm)
        {
            var rt = vm.ToMenu();
            var res = _bo.Create(rt);
            return new ObjectResult(res.Success ? HttpStatusCode.OK : HttpStatusCode.InternalServerError);
        }

        [HttpGet("{id}")]
        public ActionResult<MenuViewModel> Get(Guid id)
        {
            var res = _bo.Read(id);
            if (res.Success)
            {
                if (res.Result == null) return NotFound();
                var vm = MenuViewModel.Parse(res.Result);
                return vm;
            }
            else return new ObjectResult(HttpStatusCode.InternalServerError);
        }

        [HttpGet]
        public ActionResult<List<MenuViewModel>> List()
        {
            var res = _bo.List();
            if (!res.Success) return new ObjectResult(HttpStatusCode.InternalServerError);
            var list = new List<MenuViewModel>();
            foreach (var item in res.Result)
            {
                list.Add(MenuViewModel.Parse(item));
            }
            return list;
        }

        [HttpPut]
        public ActionResult Update([FromBody]MenuViewModel bk)
        {
            var currentResult = _bo.Read(bk.Id);
            if (!currentResult.Success) return new ObjectResult(HttpStatusCode.InternalServerError);
            var current = currentResult.Result;
            if (current == null) return NotFound();

            if (current.Date == bk.Date) return new ObjectResult(HttpStatusCode.NotModified);

            if (current.Date != bk.Date) current.Date = bk.Date;

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

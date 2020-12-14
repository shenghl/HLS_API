using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StarsAPI.Business.Admin;

namespace StarsAPI.Controllers.Admin
{
    /// <summary>
    /// 实体操作模块
    /// </summary>
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class EntityController : Controller
    {
        private EntityBLL bll = new EntityBLL();
        private readonly IWebHostEnvironment _hostingEnvironment;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="hostingEnvironment"></param>
        public EntityController(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }
        /// <summary>
        /// 生成实体类
        /// </summary>
        /// <param name="entityName"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult CreateEntity(string entityName = null)
        {
            if (entityName == null)
                return Json("参数为空");
            return Json(bll.CreateEntity(entityName, _hostingEnvironment.ContentRootPath));
        }
    }
}

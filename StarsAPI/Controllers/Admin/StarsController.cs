using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StarsAPI.Business.Admin;
using StarsAPI.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StarsAPI.Controllers
{
    /// <summary>
    /// 星系的控制器
    /// </summary>
    [ApiController]
    //[Authorize(Policy ="Admin")]//权限管理
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class StarsController : Controller
    {
        private StarBLL bll = new StarBLL();

        #region base
        /// <summary>
        /// 获取星系分页列表
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet]
        public JsonResult GetStarPageList(int pageIndex = 1, int pageSize = 10)
        {
            return Json(bll.GetPageList(pageIndex, pageSize));
        }
        /// <summary>
        /// 获取单个星系
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public JsonResult GetStarById(long id)
        {
            return Json(bll.GetById(id));
        }
        /// <summary>
        /// 添加星系
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult Add(Star entity = null)
        {
            if (entity == null)
                return Json("参数为空");
            return Json(bll.Add(entity));
        }
        /// <summary>
        /// 编辑星系
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("Student")]
        public JsonResult Update(Star entity = null)
        {
            if (entity == null)
                return Json("参数为空");
            return Json(bll.Update(entity));
        }

        /// <summary>
        /// 删除星系
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        [HttpDelete]
        public JsonResult Dels(dynamic[] ids = null)
        {
            if (ids.Length == 0)
                return Json("参数为空");
            return Json(bll.Dels(ids));
        }
        #endregion
    }
}

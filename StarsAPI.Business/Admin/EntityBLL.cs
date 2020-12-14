using StarsAPI.Comm;
using StarsAPI.IService;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarsAPI.Business.Admin
{
    public class EntityBLL
    {
        private IEntity iService = new Service.EntityServiceImpl();

        /// <summary>
        /// 生成实体类
        /// </summary>
        /// <param name="entityName"></param>
        /// <param name="contentRootPath"></param>
        /// <returns></returns>
        public MessageModel<string> CreateEntity(string entityName, string contentRootPath)
        {
            string[] arr = contentRootPath.Split('\\');
            string baseFileProvider = "";
            for (int i = 0; i < arr.Length - 1; i++)
            {
                baseFileProvider += arr[i];
                baseFileProvider += "\\";
            }
            string filePath = baseFileProvider + "StarsAPI.Entity";
            if (iService.CreateEntity(entityName, filePath))
                return new MessageModel<string> { Success = true, Msg = "生成成功" };
            else
                return new MessageModel<string> { Success = false, Msg = "生成失败" };
        }
    }
}

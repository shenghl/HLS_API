using SqlSugar;
using StarsAPI.IService;
using StarsAPI.Util;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarsAPI.Service
{
    /// <summary>
    /// 实体操作服务
    /// </summary>
    public class EntityServiceImpl : BaseDB, IEntity
    {
        public SqlSugarClient db = GetClient();

        /// <summary>
        /// 生产实体类
        /// </summary>
        /// <param name="entityName">表名</param>
        /// <param name="filePath">文件地址</param>
        /// <returns></returns>
        public bool CreateEntity(string entityName, string filePath)
        {
            try
            {
                db.DbFirst.IsCreateAttribute().Where(entityName).CreateClassFile(filePath);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Text;

namespace StarsAPI.IService
{
    public interface IEntity
    {
        /// <summary>
        /// 生成实体类
        /// </summary>
        /// <param name="entityName"></param>
        /// <param name="filePath"></param>
        /// <returns></returns>
        bool CreateEntity(string entityName,string filePath);
    }
}

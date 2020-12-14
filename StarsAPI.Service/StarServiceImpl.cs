using SqlSugar;
using StarsAPI.Comm;
using StarsAPI.IService;
using StarsAPI.Model;
using StarsAPI.Util;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace StarsAPI.Service
{
    public class StarServiceImpl : BaseDB, IStar
    {

        public SimpleClient<Star> sdb = new SimpleClient<Star>(BaseDB.GetClient());

        public bool Add(Star entity)
        {
            return sdb.Insert(entity);
        }

        public bool Dels(dynamic[] ids)
        {
            return sdb.DeleteByIds(ids);
        }

        public bool Update(Star entity)
        {
            return sdb.Update(entity);
        }

        Star IStar.Get(long id)
        {
            return sdb.GetById(id);
        }

        TableModel<Star> IStar.GetPageList(int pageIndex, int pageSize)
        {
            PageModel p = new PageModel() { PageIndex = pageIndex, PageSize = pageSize };
            Expression<Func<Star, bool>> ex = (it => 1 == 1);
            List<Star> data = sdb.GetPageList(ex, p);
            TableModel<Star> t = new TableModel<Star>();
            t.Code = 0;
            t.Count = p.PageCount;
            t.Data = data;
            t.Msg = "成功";
            return t;
        }
    }
}

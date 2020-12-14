using StarsAPI.Comm;
using StarsAPI.IService;
using StarsAPI.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarsAPI.Business.Admin
{
    public class StarBLL
    {
        private IStar IService = new Service.StarServiceImpl();

        public Star GetById(long id)
        {
            return IService.Get(id);
        }

        public TableModel<Star> GetPageList(int pageIndex, int pageSize)
        {
            return IService.GetPageList(pageIndex, pageSize);
        }

        public MessageModel<Star> Add(Star entity)
        {
            if (IService.Add(entity))
                return new MessageModel<Star> { Success = true, Msg = "操作成功" };
            else
                return new MessageModel<Star> { Success = false, Msg = "操作失败" };
        }

        public MessageModel<Star> Update(Star entity)
        {
            if (IService.Update(entity))
                return new MessageModel<Star> { Success = true, Msg = "操作成功" };
            else
                return new MessageModel<Star> { Success = false, Msg = "操作失败" };
        }

        public MessageModel<Star> Dels(dynamic[] ids)
        {
            if (IService.Dels(ids))
                return new MessageModel<Star> { Success = true, Msg = "操作成功" };
            else
                return new MessageModel<Star> { Success = false, Msg = "操作失败" };
        }
    }
}

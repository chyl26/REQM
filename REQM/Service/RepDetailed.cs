﻿using REQM.Domain;
using REQM.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace REQM.Service
{
    public class RepDetailedService
    {
        IRepository<RepDetailed> repository = new MbRepository<RepDetailed>();

        /// <summary>
        /// 创建一个
        /// </summary>
        /// <param name="repDetailed"></param>
        public void Create(RepDetailed repDetailed)
        {
            repository.Insert("InsertRepDetailed", repDetailed);
        }
        /// <summary>
        /// 通过ID查找一个
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public RepDetailed GetRepDetailedById(string repDetailedId)
        {
            RepDetailed repDetailed = repository.GetByCondition("SelectRepDetailedByCondition", new RepDetailed { RepDetailedId = repDetailedId });
            return repDetailed;
        }

        /// <summary>
        /// 获取所有
        /// </summary>
        /// <returns></returns>
        public IList<RepDetailed> GetRepDetaileds()
        {
            IList<RepDetailed> productList = repository.GetList("SelectRepDetailedByCondition", null);
            return productList;
        }

        /// <summary>
        /// 通过Id更新产品信息
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public void Update(RepDetailed repDetailed)
        {
            repository.Update("UpdateRepDetailedInfo", repDetailed);
        }

        /// <summary>
        /// 通过Id删除产品
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public void Delete(string productId)
        {
            repository.Delete("DeleteProductInfo", productId);
        }
    }
}
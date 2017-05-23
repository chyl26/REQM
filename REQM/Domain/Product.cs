using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace REQM.Domain
{
    /// <summary>
    /// 产品管理
    /// </summary>
    public class Product
    {
        [Required]
        public string ProductId { get; set; }

        [Required(ErrorMessage ="产品名称不能为空")]
        [Display(Name ="产品名称")]
        public string ProductName { get; set; }

        [Display(Name ="产品逻辑说明")]
        public string Productlogic { get; set; }

        [Display(Name ="产品特性")]
        public string Characteristic { get; set; }

        [Display(Name ="需求详细说明")]
        public  List<ReqDetailed> Detaileds { get; set; }

        [Display(Name ="交互需求说明")]
        public string Interactive { get; set; }

        [Display(Name ="数据需求")]
        public string DateRep { get; set; }

        [Display(Name ="其它需求")]
        public string OtherRep { get; set; }
    }

    /// <summary>
    /// 需求详细说明
    /// </summary>
    public class ReqDetailed
    {
        [Required]
        public string ProductId { get; set; }

        [Required]
        public string RepId { get; set; }

        [Required(ErrorMessage = "产品名称不能为空")]
        [Display(Name ="需求名称")]
        public string RepName { get; set; }

        [Display(Name ="需求描述")]
        public string RepDescribe { get; set; }
    }
}
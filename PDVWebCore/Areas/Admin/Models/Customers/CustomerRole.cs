using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PDVWebCore.Areas.Admin.Models.Customers
{
    public class CustomerRole
    {
        public int CustomerRoleID { get; set; }
        [Display(Name = "Mã quyền")]
        [StringLength(100, ErrorMessage = "Không được quá 100")]
        public string RoleCode { get; set; }
        [Display(Name = "Tên quyền")]
        [StringLength(200, ErrorMessage = "Không được quá 200")]
        public string Name { get; set; }
        [Display(Name = "Kích hoạt")]
        public bool Active { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
    }
}
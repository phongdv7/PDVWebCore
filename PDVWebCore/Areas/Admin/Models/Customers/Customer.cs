using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PDVWebCore.Areas.Admin.Models.Customers
{
    public class Customer
    {
        [Display(Name = "Tài khoản")]
        [Key]
        [StringLength(50, ErrorMessage = "Tối đa 50 ký tự")]
        public string Username { get; set; }
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        [StringLength(100, ErrorMessage = "Tối đa 50 ký tự")]
        [Required]
        public string Email { get; set; }
        [Display(Name = "Mật khẩu")]
        [DataType(DataType.Password)]
        [StringLength(50, ErrorMessage = "Tối đa 50 ký tự")]
        [Required]
        public string Password { get; set; }

        //form fields & properties
        [Display(Name = "Nhà cung cấp")] 
        public int? VendorId { get; set; }
        [Display(Name = "Tên")]
        [Required]
        [StringLength(100, ErrorMessage = "Tối đa 100 ký tự")]
        public string FirstName { get; set; }
        [Display(Name = "Họ và đệm")]
        [Required]
        [StringLength(200, ErrorMessage = "Tối đa 200 ký tự")]
        public string LastName { get; set; }
        [Display(Name = "Tên đầy đủ")]
        public string FullName
        {
            get
            {
                return LastName + " " + FirstName;
            }
        }
        [Display(Name = "Công ty")]
        [StringLength(500, ErrorMessage = "Tối đa 500 ký tự")]
        public string Company { get; set; }
        [Display(Name = "Địa chỉ")]
        [StringLength(500, ErrorMessage = "Tối đa 500 ký tự")]
        public string StreetAddress { get; set; }
        [Display(Name = "Địa chỉ 2")]
        [StringLength(500, ErrorMessage = "Tối đa 500 ký tự")]
        public string StreetAddress2 { get; set; }
        [Display(Name = "Thành phố")]
        [StringLength(100, ErrorMessage = "Tối đa 100 ký tự")]
        public string City { get; set; }
        [DataType(DataType.PhoneNumber)]
        [StringLength(15, ErrorMessage = "Tối đa 15 ký tự")]
        [Display(Name = "Điện thoại")]
        public string Phone { get; set; }
        [Display(Name = "Kích hoạt")]
        public bool Active { get; set; }
        //registration date
        [Display(Name = "Ngày tạo")]
        public DateTime CreatedOn { get; set; }
        [Display(Name = "Lần truy cập gần nhất")]
        public DateTime? LastActivityDate { get; set; }
        //IP address
        [Display(Name = "Địa chỉ IP")]
        [StringLength(50, ErrorMessage = "Tối đa 50 ký tự")]
        public string LastIpAddress { get; set; }
        [Display(Name = "Trang truy cập gần nhất")]
        [StringLength(500, ErrorMessage = "Tối đa 500 ký tự")]
        public string LastVisitedPage { get; set; }
        //customer roles
        [Display(Name = "Quyền truy cập")]
        //public virtual ICollection<CustomerRole> CustomerRole { get; set; }
        //public IList<int> SelectedCustomerRoleIds { get; set; }
        private ICollection<CustomerRole> _CustomerRoles;
        public virtual ICollection<CustomerRole> CustomerRoles
        {
            get
            {
                return _CustomerRoles ?? (_CustomerRoles = new List<CustomerRole>());
            }
            set
            {
                _CustomerRoles = value;
            }
        }
    }
}
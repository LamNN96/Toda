using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TodaSupportWeb.Models
{
    public class RequestViewModels
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Nội dung không được để trống")]
        [Display(Name = "Nội dung")]
        public string Value { get; set; }
        [Required(ErrorMessage = "Bạn phải chọn phòng ban")]
        [Display(Name = "Phòng ban")]
        public int? PhongBan { get; set; }
        [Required(ErrorMessage = "Tiêu đề không được để trống")]
        [Display(Name = "Tiêu đề")]
        [StringLength(100)]
        public string Subject { get; set; }
        [Display(Name = "Thời gian")]
        public DateTime? ThoiGian { get; set; }
    }
}
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Onion.Data.Common;

namespace Onion.Data.Music
{
    public class Singer : BaseEntity
    {
        [Display(Name = "نام خواننده")]
        [MaxLength(100, ErrorMessage = "تعداد کاراکتر های {0} نمیتواند بیشتر از {1} باشد")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string SingerName { get; set; }

        [Display(Name = "تصویر خواننده")]
        [MaxLength(100, ErrorMessage = "تعداد کاراکتر های {0} نمیتواند بیشتر از {1} باشد")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string SingerImage { get; set; }

        [Display(Name = "فعال / غیرفعال")]
        public bool IsActive { get; set; }

        [Display(Name = "حذف شده / نشده")]
        public bool IsDelete { get; set; }

        public virtual ICollection<Song> Songs { get; set; }
    }
}

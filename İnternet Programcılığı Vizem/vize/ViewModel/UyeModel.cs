using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace vize.ViewModel
{
    public class UyeModel
    {
        public int uyeId { get; set; }
        public string uyeKullaniciAdi { get; set; }
        public string uyeEmail { get; set; }
        public string uyeAdSoyad { get; set; }
        public int uyeAdmin { get; set; }
        public int uyeSatici { get; set; } 
    }
}
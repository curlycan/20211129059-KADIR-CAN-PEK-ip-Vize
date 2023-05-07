using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace vize.ViewModel
{
    public class KayitModel
    {
        public string kayitId { get; set; }
        public string kayitKategoriId { get; set; }
        public string kayitilanId { get; set; }
        public KategoriModel kategoriBilgi { get; set; }
        public İlanModel ilanBilgi { get; set; }
    }

}

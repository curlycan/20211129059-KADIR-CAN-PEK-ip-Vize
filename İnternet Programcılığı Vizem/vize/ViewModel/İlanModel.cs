using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace vize.ViewModel
{
    public class İlanModel
    {
        public string ilanId { get; set; }
        public int ilanNo { get; set; }
        public int ilanFiyat { get; set; }
        public System.DateTime ilanTarihi { get; set; }
        public string ilanEmlakTipi { get; set; }
        public int ilanMetreKareBrut { get; set; }
        public int ilanMetreKareNet { get; set; }
        public int ilanOdaSayisi { get; set; }
        public int ilanBinaYasi { get; set; }
        public int ilanBulunduguKat { get; set; }
        public int ilanKatSayisi { get; set; }
        public string ilanIsitma { get; set; }
        public int ilanBanyoSayisi { get; set; }
        public int ilanBalkon { get; set; }
        public string ilanEsyali { get; set; }
        public string ilanKullanimDurumu { get; set; }
        public string ilanAidat { get; set; }
        public string ilanKimden { get; set; }


    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using vize.Models;
using vize.ViewModel;
namespace vize.Controllers
{
    public class ServisController : ApiController
    {
        DB01Entities3 db = new DB01Entities3();
        SonucModel sonuc = new SonucModel();

        #region Kategori
        [HttpGet]
        [Route("api/kategoriliste")]
        public List<KategoriModel> KategoriListe()
        {
            List<KategoriModel> liste = db.Kategori.Select(x => new KategoriModel()
            {
                kategoriKodu = x.kategoriKodu,
                kategoriId = x.kategoriId,
                kategoriAdi = x.kategoriAdi
            }).ToList();
            return liste;
        }

        [HttpGet]
        [Route("api/kategoriById/{KategoriId}")]
        public KategoriModel KategoriById(string kategoriId)
        {
            KategoriModel kayit = db.Kategori.Where(s => s.kategoriId == kategoriId).Select(x => new
             KategoriModel()
            {
                kategoriKodu = x.kategoriKodu,
                kategoriId = x.kategoriId,
                kategoriAdi = x.kategoriAdi
            }).SingleOrDefault();
            return kayit;

        }
        [HttpPost]
        [Route("api/kategoriekle")]
        public SonucModel KategoriEkle(KategoriModel model)
        {
            if (db.Kategori.Count(s => s.kategoriKodu == model.kategoriKodu) > 0)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Girilen Kategori Kodu Kayıtlıdır";
                return sonuc;
            }
            Kategori yeni = new Kategori();
            yeni.kategoriId = Guid.NewGuid().ToString();
            yeni.kategoriKodu = model.kategoriKodu;
            yeni.kategoriAdi = model.kategoriAdi;
            db.Kategori.Add(yeni);
            db.SaveChanges();
            sonuc.islem = true;
            sonuc.mesaj = "Kategori Eklendi";
            return sonuc;
        }

        [HttpPut]
        [Route("api/kategoriduzenle")]

        public SonucModel KategoriDuzenle(KategoriModel model)
        {
            Kategori kayit = db.Kategori.Where(s => s.kategoriId == model.kategoriId).SingleOrDefault();

            if (kayit== null)
            {
                sonuc.islem = false;
                sonuc.mesaj = " Kategori Bulunamadı";
                return sonuc;
            }

            kayit.kategoriKodu = model.kategoriKodu;
            kayit.kategoriAdi = model.kategoriAdi;
            db.SaveChanges();

            sonuc.islem = true;
            sonuc.mesaj = "Kategori Düzenlendi";
            return sonuc;

        }
        [HttpDelete]
        [Route("api/kategorisil/{kategoriId}")]
        public SonucModel KategoriSil(string kategoriId)
        {
            Kategori kayit = db.Kategori.Where(s => s.kategoriId == kategoriId).SingleOrDefault();

            if(kayit==null)
            {
                sonuc.islem = false;
                sonuc.mesaj = " Kategori Bulunamadı";
                return sonuc;
            }

            if (db.Kayit.Count(s => s.kayitKategoriId == kategoriId) > 0)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Kategoriye Kayıtlı İlan Silinemez!";
                return sonuc;
            }

            db.Kategori.Remove(kayit);
            db.SaveChanges();
            sonuc.islem = true;
            sonuc.mesaj = "Kategori Silindi";

            return sonuc;

        }
        #endregion

        #region Ilanlar

        [HttpGet]
        [Route("api/ilanliste")]
        public List<İlanModel> ilanliste()
        {
            List<İlanModel> liste = db.ilan.Select(x => new İlanModel()
            {
                ilanId = x.ilanId,
                ilanNo = x.ilanNo,
                ilanFiyat = x.ilanFiyat,
                ilanTarihi = x.ilanTarihi,
                ilanEmlakTipi = x.ilanEmlakTipi,
                ilanMetreKareBrut = x.ilanMetreKareBrut,
                ilanMetreKareNet = x.ilanMetreKareNet,
                ilanOdaSayisi = x.ilanOdaSayisi,
                ilanBinaYasi = x.ilanBinaYasi,
                ilanBulunduguKat = x.ilanBulunduguKat,
                ilanKatSayisi = x.ilanKatSayisi,
                ilanIsitma = x.ilanIsitma,
                ilanBanyoSayisi = x.ilanBanyoSayisi,
                ilanBalkon = x.ilanBalkon,
                ilanEsyali = x.ilanEsyali,
                ilanKullanimDurumu = x.ilanKullanimDurumu,
                ilanAidat = x.ilanAidat,
                ilanKimden = x.ilanKimden,
                
            }).ToList();
            return liste;
        }
        [HttpGet]
        [Route("api/ilanbyid/{ilanId}")]
        public İlanModel ilanById(string ilanId)
        {
            İlanModel kayit = db.ilan.Where(s => s.ilanId == ilanId).Select(x => new İlanModel()
            {
                ilanId = x.ilanId,
                ilanNo = x.ilanNo,
                ilanFiyat = x.ilanFiyat,
                ilanTarihi = x.ilanTarihi,
                ilanEmlakTipi = x.ilanEmlakTipi,
                ilanMetreKareBrut = x.ilanMetreKareBrut,
                ilanMetreKareNet = x.ilanMetreKareNet,
                ilanOdaSayisi = x.ilanOdaSayisi,
                ilanBinaYasi = x.ilanBinaYasi,
                ilanBulunduguKat = x.ilanBulunduguKat,
                ilanKatSayisi = x.ilanKatSayisi,
                ilanIsitma = x.ilanIsitma,
                ilanBanyoSayisi = x.ilanBanyoSayisi,
                ilanBalkon = x.ilanBalkon,
                ilanEsyali = x.ilanEsyali,
                ilanKullanimDurumu = x.ilanKullanimDurumu,
                ilanAidat = x.ilanAidat,
                ilanKimden = x.ilanKimden,
                
            }).SingleOrDefault();
            return kayit;
        }
        [HttpPost]
        [Route("api/ilanekle")]
        public SonucModel ilanEkle(İlanModel model)
        
        {
            if (db.ilan.Count(s => s.ilanNo == model.ilanNo) > 0)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Girilen İlan Numarası Kayıtlıdır";
                return sonuc;
            }
            ilan yeni = new ilan();
            yeni.ilanId = Guid.NewGuid().ToString();
            
            yeni.ilanNo = model.ilanNo;
            yeni.ilanFiyat = model.ilanFiyat;
            yeni.ilanTarihi = model.ilanTarihi;
            yeni.ilanEmlakTipi = model.ilanEmlakTipi;
            yeni.ilanMetreKareBrut = model.ilanMetreKareBrut;
            yeni.ilanMetreKareNet = model.ilanMetreKareNet;
            yeni.ilanOdaSayisi = model.ilanOdaSayisi;
            yeni.ilanBinaYasi = model.ilanBinaYasi;
            yeni.ilanBulunduguKat = model.ilanBulunduguKat;
            yeni.ilanKatSayisi = model.ilanKatSayisi;
            yeni.ilanIsitma = model.ilanIsitma;
            yeni.ilanBanyoSayisi = model.ilanBanyoSayisi;
            yeni.ilanBalkon = model.ilanBalkon;
            yeni.ilanEsyali = model.ilanEsyali;
            yeni.ilanKullanimDurumu = model.ilanKullanimDurumu;
            yeni.ilanAidat = model.ilanAidat;
            yeni.ilanKimden = model.ilanKimden;
            


            db.ilan.Add(yeni);
            db.SaveChanges();
            sonuc.islem = true;
            sonuc.mesaj = "İlan Eklendi";
            return sonuc;
        }

        [HttpPut]
        [Route("api/ilanduzenle")]

        public SonucModel ilanDuzenle(İlanModel model)
        {
            ilan kayit = db.ilan.Where(s => s.ilanId == model.ilanId).SingleOrDefault();

            if (kayit == null)
            {
                sonuc.islem = false;
                sonuc.mesaj = " İlan Bulunamadı";
                return sonuc;
            }

            kayit.ilanNo = model.ilanNo;
            kayit.ilanFiyat = model.ilanFiyat;
            kayit.ilanTarihi = model.ilanTarihi;
            kayit.ilanEmlakTipi = model.ilanEmlakTipi;
            kayit.ilanMetreKareBrut = model.ilanMetreKareBrut;
            kayit.ilanMetreKareNet = model.ilanMetreKareNet;
            kayit.ilanOdaSayisi = model.ilanOdaSayisi;
            kayit.ilanBinaYasi = model.ilanBinaYasi;
            kayit.ilanBulunduguKat = model.ilanBulunduguKat;
            kayit.ilanKatSayisi = model.ilanKatSayisi;
            kayit.ilanIsitma = model.ilanIsitma;
            kayit.ilanBanyoSayisi = model.ilanBanyoSayisi;
            kayit.ilanBalkon = model.ilanBalkon;
            kayit.ilanEsyali = model.ilanEsyali;
            kayit.ilanKullanimDurumu = model.ilanKullanimDurumu;
            kayit.ilanAidat = model.ilanAidat;
            kayit.ilanKimden = model.ilanKimden;

            db.SaveChanges();

            sonuc.islem = true;
            sonuc.mesaj = "İlan Düzenlendi";
            return sonuc;
        }
        [HttpDelete]
        [Route("api/ilansil/{ilanId}")]
        public SonucModel ilanSil(string ilanId)
        {
            ilan kayit = db.ilan.Where(s => s.ilanId == ilanId).SingleOrDefault();

            if (kayit == null)
            {
                sonuc.islem = false;
                sonuc.mesaj = " İlan Bulunamadı";
                return sonuc;
            }
            if (db.Kayit.Count(s => s.kayitilanId == ilanId) > 0)
            {
                sonuc.islem = false;
                sonuc.mesaj = "İlan bir kategoriye kayıtlı olduğu için silinemez!";
                return sonuc;
            }

            db.ilan.Remove(kayit);
            db.SaveChanges();
            sonuc.islem = true;
            sonuc.mesaj = "İlan Silindi";

            return sonuc;

        }


        #endregion

        #region Kayit

        [HttpGet]
        [Route("api/ilankategoriliste/{ilanId}")]
        public List<KayitModel> ilankategoriliste(string ilanId)
        {
            List<KayitModel> liste = db.Kayit.Where(s => s.kayitilanId == ilanId).Select(x => new KayitModel()
            {
                kayitId = x.kayitId,
                kayitKategoriId = x.kayitKategoriId,
                kayitilanId = x.kayitilanId
            }).ToList();

            foreach (var kayit in liste)
            {
                kayit.ilanBilgi = ilanById(kayit.kayitilanId);
                kayit.kategoriBilgi = KategoriById(kayit.kayitKategoriId);

            }
            return liste;

        }
        [HttpGet]
        [Route("api/kategoriilanliste/{kategoriId}")]
        public List<KayitModel> kategoriilanliste(string kategoriId)
        {
            List<KayitModel> liste = db.Kayit.Where(s => s.kayitKategoriId == kategoriId).Select(x => new KayitModel()
            {
                kayitId = x.kayitId,
                kayitKategoriId = x.kayitKategoriId,
                kayitilanId = x.kayitilanId
            }).ToList();

            foreach (var kayit in liste)
            {
                kayit.ilanBilgi = ilanById(kayit.kayitilanId);
                kayit.kategoriBilgi = KategoriById(kayit.kayitKategoriId);

            }
            return liste;

        }


        #endregion

        #region Kayıt1
        [HttpPost]
        [Route("api/kayitekle")]
        public SonucModel KayitEkle(KayitModel model)
        {
            if (db.Kayit.Count(s => s.kayitilanId == model.kayitilanId & s.kayitilanId == model.kayitilanId) > 0)
            {
                sonuc.islem = false;
                sonuc.mesaj = "İlan Kategori Kaydı Önceden Yapılmıştır!";
                return sonuc;
            }

            Kayit yeni = new Kayit();
            yeni.kayitId = Guid.NewGuid().ToString();
            yeni.kayitKategoriId = model.kayitKategoriId;
            yeni.kayitilanId = model.kayitilanId;
            db.Kayit.Add(yeni);
            db.SaveChanges();
            sonuc.islem = true;
            sonuc.mesaj = "İlan Kaydı Eklendi";
            return sonuc;
        }

        [HttpDelete]
        [Route("api/kayitsil/{kayitId}")]
        public SonucModel KayitSil(string kayitId)
        {
            Kayit kayit = db.Kayit.Where(s => s.kayitId == kayitId).SingleOrDefault();

            if (kayit == null)
            {
                sonuc.islem = false;
                sonuc.mesaj = "İlan Bulunamadı!";
                return sonuc;
            }


            db.Kayit.Remove(kayit);
            db.SaveChanges();
            sonuc.islem = true;
            sonuc.mesaj = "İlan Silindi";

            return sonuc;
        }
        #endregion
    }
}

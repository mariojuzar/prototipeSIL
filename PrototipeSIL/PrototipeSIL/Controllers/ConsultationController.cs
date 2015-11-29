using PrototipeSIL.DAL;
using PrototipeSIL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PrototipeSIL.Controllers
{
    [MyAuthorize]
    public class ConsultationController : Controller
    {
        SILDBEntities db = new SILDBEntities();

        // GET: Consultation
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Pertanyaan1()
        {
            return PartialView("_Pertanyaan1");
        }

        [HttpPost]
        public ActionResult Pertanyaan2()
        {
            return PartialView("_Pertanyaan2");
        }

        [HttpPost]
        public ActionResult Pertanyaan3()
        {
            return PartialView("_Pertanyaan3");
        }

        [HttpPost]
        public ActionResult Pertanyaan4()
        {
            return PartialView("_Pertanyaan4");
        }

        [HttpPost]
        public ActionResult ShowResultConsultationYes()
        {
            return PartialView("_ShowResultConsultationYes");
        }

        [HttpPost]
        public ActionResult ShowResultConsultationNo()
        {
            return PartialView("_ShowResultConsultationNo");
        }

        [HttpPost]
        public ActionResult ShowResultDSS(String option)
        {
            List<RekomendasiSuplaiModel> model = new List<RekomendasiSuplaiModel>();
            
            if (option.Equals("EOQ"))
            {
                List<Barang> barangs = db.Barang.ToList();

                foreach (Barang barang in barangs)
                {
                    Stock stok = (from d in db.Stock
                                  where d.IDBarang == barang.IDBarang
                                  select d).Single();
                    int SS = (stok.JumlahDiGudang + stok.JumlahDiSupermarket)*5/10;

                    if (stok.JumlahDiGudang < SS)
                    {
                        BarangSupplier barSup = (from d in db.BarangSupplier
                                                 where d.IDBarang == barang.IDBarang
                                                 select d).Single();
                        Supplier supplier = (from d in db.Supplier
                                             where d.IDSupplier == barSup.IDSupplier
                                             select d).Single();

                        RekomendasiSuplaiModel item = new RekomendasiSuplaiModel();
                        item.KodeBarang = barang.IDBarang;
                        item.NamaBarang = barang.NamaBarang;
                        item.NamaSupplier = supplier.NamaSupplier;
                        int D = barang.HargaBeli*(stok.JumlahDiGudang+stok.JumlahDiSupermarket)/1000;
                        item.JumlahPasok = EconomicOrderQuantity.calculateEOQ(D, supplier.BiayaPengiriman, 2)/100;

                        model.Add(item);
                    }
                }

                return PartialView("_ShowResultEOQ", model);
            }
            else
            {
                List<Barang> barangs = db.Barang.ToList();

                foreach (Barang barang in barangs)
                {
                    Stock stok = (from d in db.Stock
                                  where d.IDBarang == barang.IDBarang
                                  select d).Single();
                    int SS = (stok.JumlahDiGudang + stok.JumlahDiSupermarket) * 5 / 10;

                    if (stok.JumlahDiGudang < SS)
                    {
                        BarangSupplier barSup = (from d in db.BarangSupplier
                                                 where d.IDBarang == barang.IDBarang
                                                 select d).Single();
                        Supplier supplier = (from d in db.Supplier
                                             where d.IDSupplier == barSup.IDSupplier
                                             select d).Single();

                        RekomendasiSuplaiModel item = new RekomendasiSuplaiModel();
                        item.KodeBarang = barang.IDBarang;
                        item.NamaBarang = barang.NamaBarang;
                        item.NamaSupplier = supplier.NamaSupplier;
                        int D = barang.HargaBeli * (stok.JumlahDiGudang + stok.JumlahDiSupermarket) / 1000;
                        
                        int[] r = new int[7];

                        for (int j = 0; j < r.Length; j++) 
                        {
                            Random rand = new Random();
                            int rj = rand.Next(3);

                            if (rj%2==0){
                                rj = rand.Next(SS-(SS/10), SS+(SS/10));
                                r[j] = rj;
                            } else {
                                r[j] = 0;
                            }
                        }

                        item.JumlahPasok = SilverMealHeuristic.calculateSMH(D, 2, r);

                        if (item.JumlahPasok != 0)
                        {
                            model.Add(item);
                        }
                    }
                }

                return PartialView("_ShowResultSMH", model);
            }
        }
    }
}
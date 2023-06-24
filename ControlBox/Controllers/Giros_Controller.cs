using ControlBox.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControlBox.Controllers
{
    public class Giros_Controller
    {
        public List<TGiros> Read()
        {
            List<TGiros> giro = new List<TGiros>();
            using (GirosDbEntities db = new GirosDbEntities())
            {
                giro = db.TGiros.ToList();
            }
            return giro;
        }
        public List<VGiros> ReadAll()
        {
            List<VGiros> giros = new List<VGiros>();
            using (GirosDbEntities db = new GirosDbEntities())
            {
                giros = db.VGiros.ToList();
            }
            return giros;
        }
        public List<VGiros> Read(TCiudades ciudad)
        {
            List<VGiros> lst = new List<VGiros>();  
            using (GirosDbEntities db = new GirosDbEntities())
            {
               var  vLstGiros = from g in db.VGiros
                                where g.Ciudad_id == ciudad.Ciudad_id   
                                select g;
                List<VGiros> lstgiros = vLstGiros.ToList() ;
                if(lstgiros != null)
                {
                    int stop = lstgiros.Count < 4 ? lstgiros.Count : 4; 
                    for (int i = 0; i< stop;i++)
                    {
                        lst.Add(lstgiros[i]);
                    }
                }
                return lst;
            }           
        }

        public VGiros ReadAll(int id)
        {
            VGiros giros = null;
            using (GirosDbEntities db = new GirosDbEntities())
            {
                var vlist = from c in db.VGiros
                            where c.Giro_id == id
                            select c;
                List<VGiros> list = vlist.ToList();
                if (list != null)
                {
                    if (list.Count > 0)
                    {
                        giros = list[0];
                    }
                }
            }
            return giros;
        }
        public TGiros Read(int id)
        {
            TGiros giros = null;
            using (GirosDbEntities db = new GirosDbEntities())
            {
                var vlist = from c in db.TGiros
                            where c.Giro_id == id
                            select c;
                List<TGiros> list = vlist.ToList();
                if (list != null)
                {
                    if (list.Count > 0)
                    {
                        giros = list[0];
                    }
                }
            }
            return giros;
        }
        public void Create(TGiros giro)
        {
            using (GirosDbEntities db = new GirosDbEntities())
            {
                db.TGiros.Add(giro);
                db.SaveChanges();
            }
        }
        public void Update(TGiros giro)
        {
            using (GirosDbEntities db = new GirosDbEntities())
            {
                db.Entry(giro).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }
        public void Delete(int id)
        {
            TGiros giro = new TGiros();
            giro.Giro_id = id;
            using (GirosDbEntities db = new GirosDbEntities())
            {
                db.Entry(giro).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
            }
        }

        
    }
}
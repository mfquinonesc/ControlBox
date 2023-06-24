using ControlBox.DB;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;

namespace ControlBox.Controllers
{
    public class Paises_Controller
    {   
        public List<TPaises> Read()
        {
            List<TPaises> paises= new List<TPaises>();
            using (GirosDbEntities db = new GirosDbEntities())
            {
                paises = db.TPaises.ToList();
            }
            return paises;
        }
        public TPaises Read(int id)
        {
            TPaises paises = null;
            using (GirosDbEntities db = new GirosDbEntities())
            {
                var vlist = from p in db.TPaises
                            where p.Pais_id == id   
                            select p;
                List<TPaises> list =  vlist.ToList();
                if(list != null)
                {
                    if(list.Count > 0)
                    {
                        paises = list[0];
                    } 
                }
            }
            return paises;            
        }
        public void Create(TPaises paises)
        {
            using(GirosDbEntities db = new GirosDbEntities()) 
            { 
                db.TPaises.Add(paises);
                db.SaveChanges();
            }
        }
        public void Update(TPaises paises)
        {
            using (GirosDbEntities db = new GirosDbEntities())
            {
                db.Entry(paises).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }
        public void Delete(int id) 
        {
            TPaises paises = new TPaises(); 
            paises.Pais_id = id;
            using (GirosDbEntities db = new GirosDbEntities())
            {
                db.Entry(paises).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
            }
        }   
       

    }
}
using ControlBox.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControlBox.Controllers
{
    public class Ciudades_Controller
    {
        public List<TCiudades> Read()
        {
            List<TCiudades> ciudades = new List<TCiudades>();
            using (GirosDbEntities db = new GirosDbEntities())
            {
                ciudades = db.TCiudades.ToList();
            }
            return ciudades;
        }
        public List<VCiudades> ReadAll()
        {
            List<VCiudades> ciudades = new List<VCiudades>();
            using (GirosDbEntities db = new GirosDbEntities())
            {
                ciudades = db.VCiudades.ToList();
            }
            return ciudades;
        }
        public TCiudades Read(int id)
        {
            TCiudades ciudad = null;
            using (GirosDbEntities db = new GirosDbEntities())
            {
                var vlist = from c in db.TCiudades
                            where c.Ciudad_id == id
                            select c;
                List<TCiudades> list = vlist.ToList();
                if (list != null)
                {
                    if (list.Count > 0)
                    {
                        ciudad = list[0];
                    }
                }
            }
            return ciudad;
        }
        public void Create(TCiudades ciudad)
        {
            using (GirosDbEntities db = new GirosDbEntities())
            {
                db.TCiudades.Add(ciudad);
                db.SaveChanges();
            }
        }
        public void Update(TCiudades ciudad)
        {
            using (GirosDbEntities db = new GirosDbEntities())
            {
                db.Entry(ciudad).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }
        public void Delete(int id)
        {
            TCiudades ciudad = new TCiudades();
            ciudad.Ciudad_id = id;
            using (GirosDbEntities db = new GirosDbEntities())
            {
                db.Entry(ciudad).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
            }
        }
    }
}
using DataAccess;
using Entities;
using System.Reflection.Metadata;
using static System.Net.Mime.MediaTypeNames;


namespace Business
{
    public class TB_Tasas
    {
        public static List<TasasEntity> TasaList()
        {
            using (var db = new PersonalContext())
            {
                return db.TBTasas.ToList();
            }
        }

        public static string GetTasaNameById(int id)
        {
            using (var db = new PersonalContext())
            {
                TasasEntity rol = db.TBTasas.FirstOrDefault(p => p.TasaID == id);
                return rol.TasaName;
            }
        }

        public static int GetTasaIdByName(string name)
        {
            using (var db = new PersonalContext())
            {
                TasasEntity rol = db.TBTasas.FirstOrDefault(p => p.TasaName == name);
                return rol.TasaID;
            }
        }

        public static void CreateTasa(string nombre)
        {
            using (var db = new PersonalContext())
            {
                var nuevaTasa = new TasasEntity
                {
                    TasaName = nombre
                };

                db.TBTasas.Add(nuevaTasa);
                db.SaveChanges();
            }
        }

        public static void UpdateTasa(int id, string nombre)
        {
            using (var db = new PersonalContext())
            {
                var rol = db.TBTasas.FirstOrDefault(p => p.TasaID == id);
                if (rol != null)
                {
                    rol.TasaName = nombre;
                    db.SaveChanges();
                }
            }
        }

        public static void RemoveTasa(int id)
        {
            using (var db = new PersonalContext())
            {
                TasasEntity obtTasa = db.TBTasas.FirstOrDefault(o => o.TasaID == id);
                db.TBTasas.Remove(obtTasa);
                db.SaveChanges();
            }
        }
    }
}


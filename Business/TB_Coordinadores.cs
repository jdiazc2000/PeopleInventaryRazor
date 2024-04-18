using DataAccess;
using Entities;

namespace Business
{
    public class TB_Coordinadores
    {
        public static List<CoordinadoresEntity> CoordinadoresList()
        {
            using (var db = new PersonalContext())
            {
                return db.TBCoordinadores.ToList();
            }
        }

        public static string GetNombreById(int id)
        {
            using (var db = new PersonalContext())
            {
                CoordinadoresEntity coordinador = db.TBCoordinadores.FirstOrDefault(p => p.CoordinadorID == id);
                return coordinador.Nombre;
            }
        }

        public static int GetCoordinadorIdByName(string name)
        {
            using (var db = new PersonalContext())
            {
                CoordinadoresEntity coordinador = db.TBCoordinadores.FirstOrDefault(p => p.Nombre == name);
                return coordinador.CoordinadorID;
            }
        }

        public static void CreateCoordinador(string nombre)
        {
            using (var db = new PersonalContext())
            {
                var nuevoCoordinador = new CoordinadoresEntity
                {
                    Nombre = nombre
                };

                db.TBCoordinadores.Add(nuevoCoordinador);
                db.SaveChanges();
            }
        }

        public static void UpdateCoordinador(int id, string nombre)
        {
            using (var db = new PersonalContext())
            {
                var coodinador = db.TBCoordinadores.FirstOrDefault(p => p.CoordinadorID == id);
                if (coodinador != null)
                {
                    coodinador.Nombre = nombre;
                    db.SaveChanges();
                }
            }
        }

        public static void RemoveCoordinador(int id)
        {
            using (var db = new PersonalContext())
            {
                CoordinadoresEntity objCoordinador = db.TBCoordinadores.FirstOrDefault(o => o.CoordinadorID == id);
                db.TBCoordinadores.Remove(objCoordinador);
                db.SaveChanges();
            }
        }
    }
}


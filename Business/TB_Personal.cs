using DataAccess;
using Entities;

namespace Business
{
    public class TB_Personal
    {
        public static List<PersonalEntity> PersonalList()
        {
            using (var db = new PersonalContext())
            {
                return db.TBPersonal.ToList();
            }
        }

        public static PersonalEntity PersonalById(double id)
        {
            using (var db = new PersonalContext())
            {
                return db.TBPersonal.ToList().LastOrDefault(p => p.ID == id);
            }
        }

        public static void CreatePersonal(PersonalEntity objCategoria)
        {
            using (var db = new PersonalContext())
            {
                db.TBPersonal.Add(objCategoria);
                db.SaveChanges();
            }
        }

        public static void UpdatePersonal(PersonalEntity objCategoria)
        {
            using (var db = new PersonalContext())
            {
                db.TBPersonal.Update(objCategoria);
                db.SaveChanges();
            }
        }

        public static void RemovePersonal(PersonalEntity objCategoria)
        {
            using (var db = new PersonalContext())
            {
                db.TBPersonal.Remove(objCategoria);
                db.SaveChanges();
            }
        }
    }
}


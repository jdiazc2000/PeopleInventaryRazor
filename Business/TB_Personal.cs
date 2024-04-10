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

        public static void CreatePersonal(PersonalEntity objPersonal)
        {
            using (var db = new PersonalContext())
            {
                db.TBPersonal.Add(objPersonal);
                db.SaveChanges();
            }
        }

        public static void UpdatePersonal(PersonalEntity objPersonal)
        {
            using (var db = new PersonalContext())
            {
                db.TBPersonal.Update(objPersonal);
                db.SaveChanges();
            }
        }

        public static void RemovePersonal(PersonalEntity objPersonal)
        {
            using (var db = new PersonalContext())
            {
                db.TBPersonal.Remove(objPersonal);
                db.SaveChanges();
            }
        }
    }
}


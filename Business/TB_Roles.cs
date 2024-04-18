using DataAccess;
using Entities;
using System.Reflection.Metadata;
using static System.Net.Mime.MediaTypeNames;


namespace Business
{
    public class TB_Roles
    {
        public static List<RolesEntity> RolList()
        {
            using (var db = new PersonalContext())
            {
                return db.TBRoles.ToList();
            }
        }

        public static string GetRolNameById(int id)
        {
            using (var db = new PersonalContext())
            {
                RolesEntity rol = db.TBRoles.FirstOrDefault(p => p.RoleID == id);
                return rol.RoleName;
            }
        }

        public static int GetRolIdByName(string name)
        {
            using (var db = new PersonalContext())
            {
                RolesEntity rol = db.TBRoles.FirstOrDefault(p => p.RoleName == name);
                return rol.RoleID;
            }
        }

        public static void CreateRol(string nombre)
        {
            using (var db = new PersonalContext())
            {
                var nuevoRol = new RolesEntity
                {
                    RoleName = nombre
                };

                db.TBRoles.Add(nuevoRol);
                db.SaveChanges();
            }
        }

        public static void UpdateRol(int id, string nombre)
        {
            using (var db = new PersonalContext())
            {
                var rol = db.TBRoles.FirstOrDefault(p => p.RoleID == id);
                if (rol != null)
                {
                    rol.RoleName = nombre;
                    db.SaveChanges();
                }
            }
        }

        public static void RemoveRol(int id)
        {
            using (var db = new PersonalContext())
            {
                RolesEntity objRol = db.TBRoles.FirstOrDefault(o => o.RoleID == id);
                db.TBRoles.Remove(objRol);
                db.SaveChanges();
            }
        }
    }
}


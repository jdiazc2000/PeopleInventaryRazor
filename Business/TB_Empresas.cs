using DataAccess;
using Entities;
using System.Reflection.Metadata;
using static System.Net.Mime.MediaTypeNames;


namespace Business
{
    public class TB_Empresas
    {
        public static List<EmpresasEntity> EmpresasList()
        {
            using (var db = new PersonalContext())
            {
                return db.TBEmpresas.ToList();
            }
        }

        public static string GetEmpresaNameById(int id)
        {
            using (var db = new PersonalContext())
            {
                EmpresasEntity empresa = db.TBEmpresas.FirstOrDefault(p => p.EmpresaID == id);
                return empresa.EmpresaName;
            }
        }

        public static int GetEmpresaIdByName(string name)
        {
            using (var db = new PersonalContext())
            {
                EmpresasEntity empresa = db.TBEmpresas.FirstOrDefault(p => p.EmpresaName == name);
                return empresa.EmpresaID;
            }
        }

        public static void CreateEmpresa(string nombre)
        {
            using (var db = new PersonalContext())
            {
                var nuevoRol = new EmpresasEntity
                {
                    EmpresaName = nombre
                };

                db.TBEmpresas.Add(nuevoRol);
                db.SaveChanges();
            }
        }

        public static void UpdateEmpresa(int id, string nombre)
        {
            using (var db = new PersonalContext())
            {
                var empresa = db.TBEmpresas.FirstOrDefault(p => p.EmpresaID == id);
                if (empresa != null)
                {
                    empresa.EmpresaName = nombre;
                    db.SaveChanges();
                }
            }
        }

        public static void RemoveEmpresa(int id)
        {
            using (var db = new PersonalContext())
            {
                EmpresasEntity objRol = db.TBEmpresas.FirstOrDefault(o => o.EmpresaID == id);
                db.TBEmpresas.Remove(objRol);
                db.SaveChanges();
            }
        }
    }
}


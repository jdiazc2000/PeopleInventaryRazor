using DataAccess;
using Entities;

namespace Business
{
    public class TB_ubigeo_peru_departments
    {
        public static List<DepartamentoEntity> DepartmentslList()
        {
            using (var db = new PersonalContext())
            {
                return db.ubigeo_peru_departments.ToList();
            }
        }

        public static string GetDepartmentName(string DepartmentId)
        {
            using (var db = new PersonalContext())
            {
                DepartamentoEntity departamento = db.ubigeo_peru_departments.FirstOrDefault(p => p.id == DepartmentId);
                return departamento?.name;
            }
        }

        public static string GetDepartmentId(string DepartmentName)
        {
            using (var db = new PersonalContext())
            {
                DepartamentoEntity departamento = db.ubigeo_peru_departments.FirstOrDefault(p => p.name == DepartmentName);
                return departamento?.id;
            }
        }


    }
}



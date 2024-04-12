using DataAccess;
using Entities;

namespace Business
{
    public class TB_ubigeo_peru_provinces
    {
        public static List<ProvinciasEntity> ProvinceslList()
        {
            using (var db = new PersonalContext())
            {
                return db.ubigeo_peru_provinces.ToList();
            }
        }
        public static string getProvinceName(string ProvinceId)
        {
            using (var db = new PersonalContext())
            {
                ProvinciasEntity provincia = db.ubigeo_peru_provinces.FirstOrDefault(p => p.id == ProvinceId);
                return provincia?.name;
            }
        }

        public static string GetProvincetId(string ProvinceName)
        {
            using (var db = new PersonalContext())
            {
                ProvinciasEntity provincia = db.ubigeo_peru_provinces.FirstOrDefault(p => p.name == ProvinceName);
                return provincia?.id;
            }
        }



        public static List<ProvinciasEntity> ProvinceslByDepartmentId(string DepartmentId)
        {
            using (var db = new PersonalContext())
            {
                return db.ubigeo_peru_provinces.Where(p => p.department_id == DepartmentId).ToList();
            }
        }
    }
}


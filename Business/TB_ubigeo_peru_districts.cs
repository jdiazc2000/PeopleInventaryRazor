using DataAccess;
using Entities;

namespace Business
{
    public class TB_ubigeo_peru_districts
    {
        public static List<DistritosEntity> DistrictsList()
        {
            using (var db = new PersonalContext())
            {
                return db.ubigeo_peru_districts.ToList();
            }
        }

        public static string GetDisctrictId(string DisctrictName)
        {
            using (var db = new PersonalContext())
            {
                DistritosEntity distrito = db.ubigeo_peru_districts.FirstOrDefault(p => p.name == DisctrictName);
                return distrito?.id;
            }
        }

        public static string getDisctrictName(string DistrictId)
        {
            using (var db = new PersonalContext())
            {
                DistritosEntity distrito = db.ubigeo_peru_districts.FirstOrDefault(p => p.id == DistrictId);
                return distrito?.name;
            }
        }

        public static List<DistritosEntity> DistrictslByProvinceId(string ProvinceId)
        {
            using (var db = new PersonalContext())
            {
                return db.ubigeo_peru_districts.Where(p => p.province_id == ProvinceId).ToList();
            }
        }

    }
}


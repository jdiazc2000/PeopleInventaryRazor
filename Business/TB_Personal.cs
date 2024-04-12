﻿using DataAccess;
using Entities;
using System.Reflection.Metadata;


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

        public static List<PersonalEntity> FilterPersonal(string Dni, string Nombre, DateTime? FechaIngreso, DateTime? FechaNacimiento, string Estado, string Equipo, string Departamento, string Provincia, string Distrito, string IdEmpleado)
        {
            using (var db = new PersonalContext())
            {
                var query = db.TBPersonal.AsQueryable();

                if (!string.IsNullOrEmpty(Dni))
                {
                    query = query.Where(v => v.DNI.Contains(Dni));
                }

                if (!string.IsNullOrEmpty(Nombre))
                {
                    query = query.Where(v => v.PERSONAL.Contains(Nombre));
                }

                if (FechaIngreso != null)
                {
                    query = query.Where(v => v.INGRESO_INDRA == FechaIngreso);
                }

                if (FechaNacimiento != null)
                {
                    query = query.Where(v => v.CUMPLEAÑOS == FechaNacimiento);
                }

                if (!string.IsNullOrEmpty(Estado))
                {
                    query = query.Where(v => v.ESTADO == Estado);
                }

                if (!string.IsNullOrEmpty(Equipo))
                {
                    query = query.Where(v => v.Equipo == Equipo);
                }

                if (!string.IsNullOrEmpty(Departamento))
                {
                    query = query.Where(v => v.DEPARTAMENTO == Departamento);
                }

                if (!string.IsNullOrEmpty(Provincia))
                {
                    query = query.Where(v => v.PROVINCIA == Provincia);
                }

                if (!string.IsNullOrEmpty(Distrito))
                {
                    query = query.Where(v => v.DISTRITO == Distrito);
                }

                if (IdEmpleado != null && IdEmpleado != "")
                {
                    query = query.Where(v => v.ID == Convert.ToDouble(IdEmpleado));
                }

                return query.ToList();
            }
        }


        public static void ChangePersonalStatus(PersonalEntity objPersonal, string text)
        {
            using (var db = new PersonalContext())
            {
                var personal = db.TBPersonal.FirstOrDefault(p => p.ID == objPersonal.ID);
                if (personal != null)
                {
                    personal.ESTADO = text;
                    db.SaveChanges();
                }
            }
        }
    }
}


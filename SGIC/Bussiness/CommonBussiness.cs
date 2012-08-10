using System;
using System.Collections.Generic;
using System.Linq;
using SGIC.Models;
using SGIC.DAL;
using SGIC.CustomHelpers;

namespace SGIC.Bussiness
{
    public class CommonBussiness
    {
        public static SGICContext db = new SGICContext();

        public static void SetDia(Viaje item)
        {
            Dia dia = db.Dias.Where(d => d.fecha == item.fecha).Single();
                //(from d in db.Dias
                //       select d).ToList<Dia>().Find(x => x.fecha == item.fecha);

            if (dia == null)
            {
                dia = new Dia { fecha = DateTime.Today };
                SetSemana(dia);
                db.Dias.Add(dia);
            }
            item.dia = dia;
        }

        public static void SetSemana(Dia item)
        {
            Semana sem = (from s in db.Semanas
                          select s).ToList<Semana>().Find(s => item.fecha >= s.fechaInicio && item.fecha <= s.fechaFin);
            if (sem == null)
            {
                sem = new Semana
                {
                    fechaInicio = DateTimeHelper.FirstDateOfWeek(item.fecha),
                    fechaFin = DateTimeHelper.FirstDateOfWeek(item.fecha).AddDays(6)
                };
                SetQuincena(sem);
                db.Semanas.Add(sem);
            }
            item.semana = sem;
        }

        public static void SetQuincena(Semana item)
        {
            Quincena qui = (from q in db.Quincenas
                            select q).ToList<Quincena>().Find(q => item.fechaInicio >= q.fechaInicio && item.fechaFin <= q.fechaFin);
            if (qui == null)
            {
                qui = new Quincena
                {
                    fechaInicio = item.fechaInicio,
                    fechaFin = item.fechaInicio.AddDays(14),
                    name = item.fechaInicio.ToShortDateString() + " - " + item.fechaInicio.AddDays(14).ToShortDateString()
                };
                db.Quincenas.Add(qui);
            }
            item.quincena = qui;
        }
    }
}
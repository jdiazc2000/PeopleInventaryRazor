namespace PersonalWeb.Services
{
    public interface ICalcServices
    {
       string CalcularDiasCese(DateTime? FechaCese);

       string CalcularDiasDeDiferencia(DateTime? FechaIngresoIndra);
    }

    public class CalcServices : ICalcServices
    {
        public string CalcularDiasCese(DateTime? FechaCese)
        {
            string diasCese;
            DateTime Hoy = DateTime.Today;

            if (!FechaCese.HasValue)
            {
                return diasCese = null;
            }
            else if (FechaCese.Value.Date < Hoy)
            {
                TimeSpan diferenciaDiasCese = Hoy - FechaCese.Value;

                return diasCese = "-" + diferenciaDiasCese.Days.ToString();
            }
            else
            {
                TimeSpan diferenciaDiasCese = FechaCese.Value - Hoy;

                return diasCese = diferenciaDiasCese.Days.ToString();
            }
        }

        public string CalcularDiasDeDiferencia(DateTime? FechaIngresoIndra)
        {
            var DiasDeDiferencia = 0;
            TimeSpan diferencia = DateTime.Now - FechaIngresoIndra.Value;
            if ((int)diferencia.TotalDays > 0)
            {
                DiasDeDiferencia = (int)diferencia.TotalDays;
            }
            else
            {
                DiasDeDiferencia = 1;
            }
            return DiasDeDiferencia.ToString();
        }

    }

}

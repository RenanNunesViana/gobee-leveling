using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdontologicManagment.utils
{
    public class Utilities
    {
        public static DateTime FormataDataCliente(String data, String padrao)
        {
            if (!DateTime.TryParseExact(data, padrao, CultureInfo.InvariantCulture, DateTimeStyles.None, out var parsedDate))
            {
                throw new ArgumentException("Data de nascimento inválida. Use o formato DDMMAAAA.");
            }
            return parsedDate;
        }

        public static DateTime FormataDataConsulta(String data, String padrao)
        {
            if (!DateTime.TryParseExact(data, padrao, CultureInfo.InvariantCulture, DateTimeStyles.None, out var parsedDate))
            {
                throw new ArgumentException("Data de consulta inválida. Use o formato DDMMAAAA.");
            }

            return parsedDate;
        }

        public static TimeSpan FormataHoraConsulta(String hora, String padrao)
        {
            if (!TimeSpan.TryParseExact(hora, padrao, CultureInfo.InvariantCulture, TimeSpanStyles.None, out var parsedHora))
            {
                throw new ArgumentException("Hora inicial inválida. Use o formato HHMM.");
            }
            return parsedHora;
        }
    }
}

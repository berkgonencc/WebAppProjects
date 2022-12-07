using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BusReservation.Core
{
    public class Jobs
    {
        public static string CreateMessage(string title,string message, string alertType)
        {
            AlertMessage msg = new AlertMessage()
            {
                Title = title,
                Message = message,
                AlertType = alertType
            };
            //TempData moves data in JSON format
            return JsonConvert.SerializeObject(msg);
        }
    }
}

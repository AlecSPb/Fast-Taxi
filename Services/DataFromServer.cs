using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Babat_Taxi.Services
{
    public class DataFromServer : IDataFromServer
    {
        public dynamic DataBase { get; set; }


        public void GetData()
        {
            HttpClient http = new HttpClient();
            var response = http.GetAsync(@"http://dev.virtualearth.net/REST/v1/Routes?wayPoint.1={wayPpoint1}&viaWaypoint.2={viaWaypoint2}&waypoint.3={waypoint3}&wayPoint.n={waypointN}&heading={heading}&optimize={optimize}&avoid={avoid}&distanceBeforeFirstTurn={distanceBeforeFirstTurn}&routeAttributes={routeAttributes}&timeType={timeType}&dateTime={dateTime}&maxSolutions={maxSolutions}&tolerances={tolerances}&distanceUnit={distanceUnit}&key={BingMapsKey}").Result;
            dynamic data = JsonConvert.DeserializeObject(response.Content.ReadAsStringAsync().Result);

        }

    }
}

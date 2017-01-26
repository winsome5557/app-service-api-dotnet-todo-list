using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TNetWebApi.Respository
{

    public class Station
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }

    /// <summary>
    ///  Class for repository
    /// </summary>
    public class StationsRepository
    {
        public List<Station> StationNames { get; set; }



        public StationsRepository()
        {
            StationNames = new List<Station>() { new Station() { ID=1, Name="Hillingdon" }, new Station() { ID = 1, Name="Uxbridge" }, new Station() { ID = 1, Name="Ickenham" }, new Station() { ID = 1, Name="Riuslip" } };
        }


        public IEnumerable<Station> GetStations()
        {
            return StationNames;
        }

        public IEnumerable<Station> AddStation(string station, int id)
        {
            if(!StationNames.Exists(s=>s.ID.Equals(id)))
            {
                StationNames.Add(new Station() { ID= id,Name= station});
            }
            return StationNames; 
        }

        public Station GetStationByID(int id)
        {
            Station station = StationNames.Where(s => s.ID.Equals(id)).FirstOrDefault();
            return station;
        }

        internal void AddStation(string value)
        {
            // get max id
            int maxId = StationNames.Select(s => s.ID).ToList().Max();
            StationNames.Add(new Station { ID = maxId + 1, Name = value });
        }

        public IEnumerable<Station> RemoveStation(int Id)
        {
            Station objToRem = StationNames.Find(s => s.ID.Equals(Id));
            if(objToRem != null)
            {
                StationNames.Remove(objToRem);
            }
            return StationNames; 
        }


        public IEnumerable<Station> UpdateStation(int Id, string value)
        {
            Station objToUpdate = StationNames.Find(s => s.ID.Equals(Id));
            
            if (objToUpdate != null)
            {
                StationNames.Remove(objToUpdate);
                objToUpdate.Name = value;
                StationNames.Add(objToUpdate);
            }

            return StationNames;
        }

    }
}
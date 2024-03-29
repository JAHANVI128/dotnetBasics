﻿namespace ServiceLibrary
{
    public class CitiesService
    {
        private List<string> _cities;

        public CitiesService()
        {
            _cities = new List<string>
            {
                "New York",
                "Los Angeles",
                "Chicago",
                "Houston",
                "Phoenix",
                "Philadelphia",
                "San Antonio",
                "San Diego",
                "Dallas",
                "San Jose"
            };
        }

        public List<string> GetCities()
        {
            return _cities;
        }
    }
}

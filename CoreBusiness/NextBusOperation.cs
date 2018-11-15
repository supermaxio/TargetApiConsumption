/***************************************************************************/
// <copyright file="NextBusOperation.cs" company="my company">
//     MyCompany.com. All rights reserved.
// </copyright>
// <author>M. Meier</author>
/***************************************************************************/

namespace CoreBusiness
{
    using System;
    using System.Linq;
    using Newtonsoft.Json;

    /// <summary>
    /// Next bus.
    /// </summary>
    public class NextBusOperation
    {
        /// <summary>
        /// Gets the time in minutes for next bus.
        /// </summary>
        /// <returns>The time in minutes for next bus.</returns>
        /// <param name="routeInput">Route input.</param>
        /// <param name="stopInput">Stop input.</param>
        /// <param name="directionInput">Direction input.</param>
        public int GetTimeInMinutesForNextBus(string routeInput, string stopInput, string directionInput)
        {
            // Check for validity
            if (string.IsNullOrWhiteSpace(routeInput))
            {
                throw new ApplicationException("Bus route name cannot be empty");
            }

            if (string.IsNullOrWhiteSpace(stopInput))
            {
                throw new ApplicationException("Bus stop name cannot be empty");
            }

            switch (directionInput)
            {
                case "east":
                    directionInput = "EASTBOUND";
                    break;
                case "north":
                    directionInput = "NORTHBOUND";
                    break;
                case "south":
                    directionInput = "SOUTHBOUND";
                    break;
                case "west":
                    directionInput = "WESTBOUND";
                    break;
                default:
                    throw new ApplicationException("Bus direction is invalid");
            }

            // Set variables
            var routeIdentifier = string.Empty;
            var directionIndentifier = string.Empty;
            var stopIdentifier = string.Empty;
            var restMetro = new RestMetroTransitNexTrip();

            // Get routes first
            var routes = restMetro.GetRoutes();

            // Check if any routes match input
            foreach (var routeDictionary in routes)
            {
                if (routeDictionary["Description"].ToLower().Contains(routeInput.ToLower()))
                {
                    routeIdentifier = routeDictionary["Route"];
                    break;
                }
            }

            // If no route found, throw to show error dialog
            if (routeIdentifier == string.Empty)
            {
                throw new ApplicationException("Bus route is invalid");
            }

            // Get direction next
            var directions = restMetro.GetDirectionsForRoute(routeIdentifier);

            // Check if any directions match input
            foreach (var directionDictionary in directions)
            {
                if (directionDictionary["Text"].ToLower() == directionInput.ToLower())
                {
                    directionIndentifier = directionDictionary["Value"];
                    break;
                }
            }

            // If no direction found, throw to show error dialog
            if (directionIndentifier == string.Empty)
            {
                throw new ApplicationException("Bus direction is invalid");
            }

            // Get stops next
            var stops = restMetro.GetStopsForRouteAndDirection(routeIdentifier, directionIndentifier);

            // Check if any stops match input
            foreach (var stopDictionary in stops)
            {
                if (stopDictionary["Text"].ToLower() == stopInput.ToLower())
                {
                    stopIdentifier = stopDictionary["Value"];
                    break;
                }
            }

            // If no stop found, throw to show error dialog
            if (stopIdentifier == string.Empty)
            {
                throw new ApplicationException("Bus stop is invalid");
            }

            // Get info next
            var info = restMetro.GetInfoForRouteAndDirectionAndStop(routeIdentifier, directionIndentifier, stopIdentifier);
            if (info.Count <= 0)
            {
                throw new ApplicationException("There are no scheduled stops here");
            }

            var firstInfo = info.FirstOrDefault();
            var dateTimeForBus = JsonConvert.DeserializeObject<DateTime>(this.WrapStringInQuotes(firstInfo["DepartureTime"]));
            var timeUntilNextBus = dateTimeForBus - DateTime.Now;
            var timeInMinutes = (int)timeUntilNextBus.TotalMinutes;
            return timeInMinutes;
        }

        private string WrapStringInQuotes(string input)
        {
            return @"""" + input + @"""";
        }
    }
}

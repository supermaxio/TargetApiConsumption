/***************************************************************************/
// <copyright file="RestMetroTransitNexTrip.cs" company="my company">
//     MyCompany.com. All rights reserved.
// </copyright>
// <author>M. Meier</author>
/***************************************************************************/

namespace CoreBusiness
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    /// <summary>
    /// Rest metro transit nex trip.
    /// </summary>
    internal class RestMetroTransitNexTrip
    {
        /// <summary>
        /// Gets the routes.
        /// </summary>
        /// <returns>The routes.</returns>
        public List<Dictionary<string, string>> GetRoutes()
        {
            var restClient = new RestClient
            {
                EndPoint = "http://svc.metrotransit.org/NexTrip/Routes"
            };

            var responseString = restClient.MakeRequest();

            var routes = (List<Dictionary<string, string>>)JsonConvert.DeserializeObject(responseString, typeof(List<Dictionary<string, string>>), new JsonSerializerSettings());
            return routes;
        }

        /// <summary>
        /// Gets the directions.
        /// </summary>
        /// <returns>The directions.</returns>
        /// <param name="route">Route.</param>
        public List<Dictionary<string,string>> GetDirectionsForRoute(string route)
        {
            var restClient = new RestClient
            {
                EndPoint = "http://svc.metrotransit.org/NexTrip/Directions/" + route
            };

            var responseString = restClient.MakeRequest();

            var directions = (List<Dictionary<string, string>>)JsonConvert.DeserializeObject(responseString, typeof(List<Dictionary<string, string>>), new JsonSerializerSettings());
            return directions;
        }

        /// <summary>
        /// Gets the stops for route and direction.
        /// </summary>
        /// <returns>The stops for route and direction.</returns>
        /// <param name="route">Route.</param>
        /// <param name="direction">Direction.</param>
        public List<Dictionary<string, string>> GetStopsForRouteAndDirection(string route, string direction)
        {
            var restClient = new RestClient
            {
                EndPoint = "http://svc.metrotransit.org/NexTrip/Stops/" + route + "/" + direction
            };

            var responseString = restClient.MakeRequest();

            var stops = (List<Dictionary<string, string>>)JsonConvert.DeserializeObject(responseString, typeof(List<Dictionary<string, string>>), new JsonSerializerSettings());
            return stops;
        }

        /// <summary>
        /// Gets info for route and direction and stop.
        /// </summary>
        /// <returns>The info for route and direction and stop.</returns>
        /// <param name="route">Route.</param>
        /// <param name="direction">Direction.</param>
        /// <param name="stop">Stop.</param>
        public List<Dictionary<string, string>> GetInfoForRouteAndDirectionAndStop(string route, string direction, string stop)
        {
            var restClient = new RestClient
            {
                 EndPoint = "http://svc.metrotransit.org/NexTrip/" + route + "/" + direction + "/" + stop
            };

            var responseString = restClient.MakeRequest();

            var info = (List<Dictionary<string, string>>)JsonConvert.DeserializeObject(responseString, typeof(List<Dictionary<string, string>>), new JsonSerializerSettings());
            return info;
        }
    }
}

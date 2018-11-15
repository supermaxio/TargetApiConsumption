/***************************************************************************/
// <copyright file="RestClient.cs" company="my company">
//     MyCompany.com. All rights reserved.
// </copyright>
// <author>M. Meier</author>
/***************************************************************************/

namespace TargetApiConsumption
{
    using System;
    using System.IO;
    using System.Net;
    using System.Text;

    /// <summary>
    /// Rest client.
    /// </summary>
    public class RestClient
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:TargetApiConsumption.RestClient"/> class.
        /// </summary>
        public RestClient()
        {
            this.EndPoint = string.Empty;
            this.HttpMethod = HttpVerb.GET;
        }

        /// <summary>
        /// Gets or sets the end point.
        /// </summary>
        /// <value>The end point.</value>
        public string EndPoint { get; set; }

        /// <summary>
        /// Gets or sets the http method.
        /// </summary>
        /// <value>The http method.</value>
        public HttpVerb HttpMethod { get; set; }

        public string MakeRequest()
        {
            var responseString = string.Empty;

            var request = (HttpWebRequest)WebRequest.Create(this.EndPoint);
            request.Method = HttpMethod.ToString();
            request.ContentType = "application/json; charset=utf-8";

            // Check if can connect
            using (var response = (HttpWebResponse)request.GetResponse())
            {
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    throw new ApplicationException("Web Server returned status code: " + response.StatusCode.ToString());
                }

                // Start stream and process it
                using (var responseStream = response.GetResponseStream())
                {
                    if (responseStream != null)
                    {
                        using (var streamReader = new StreamReader(responseStream, Encoding.UTF8))
                        {
                            responseString = streamReader.ReadToEnd();
                        }
                    }
                }
            }

            return responseString;
        }

        /// <summary>
        /// Http verb enumeration
        /// </summary>
        public enum HttpVerb
        {
            GET,
            POST,
            PUT,
            DELETE
        }
    }
}

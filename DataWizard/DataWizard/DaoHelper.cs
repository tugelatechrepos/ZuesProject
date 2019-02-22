using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DataWizard
{
    public class DaoHelperRequest
    {
        public string Endpoint { get; set; }
        public object RequestBody { get; set; }
        public bool UseServiceUri { get; set; }
    }

    public class DaoHelperResponse
    {
        public string data { get; set; }

    }

    public class DaoHelper
    {
        #region Declarations

        private string _Uri = $@"{ConfigurationManager.AppSettings["DatabaseServiceUri"]}";
        private string _ServiceUri = $@"{ConfigurationManager.AppSettings["ApplicationServiceUri"]}";

        #endregion Declarations

        public DaoHelperResponse Execute(DaoHelperRequest Request)
        {
            var daoHelperResponse = new DaoHelperResponse();

            var url = Request.UseServiceUri ? $"{_ServiceUri}{Request.Endpoint}" : $"{_Uri}{Request.Endpoint}";
            var webrequest = (HttpWebRequest)WebRequest.Create(url);
            webrequest.Method = Request.RequestBody != null ? "POST" : "GET";


            if (webrequest.Method == "POST")
            {
                var post = JsonConvert.SerializeObject(Request.RequestBody);
                webrequest.ContentType = "application/json";
                webrequest.ContentLength = post.Length;

                using (var stream = new StreamWriter(webrequest.GetRequestStream()))
                {
                    stream.Write(post);
                    stream.Close();
                }
            }

            var webresponse = (HttpWebResponse)webrequest.GetResponse();
            var responseStream = webresponse.GetResponseStream();
            var streamReader = new StreamReader(responseStream);
            var result = streamReader.ReadToEnd();
            var data = JsonConvert.DeserializeObject<object>(result);

            daoHelperResponse.data = Convert.ToString(data);

            return daoHelperResponse;
        }
    }
}

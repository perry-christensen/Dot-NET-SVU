using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Script.Serialization;

namespace helloJSON
{
    /// <summary>
    /// Summary description for ajaxJSON
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class ajaxJSON : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public string baseJSON(string name, string email)
        {
            var keyValues = new Dictionary<string, string>
            {
                {"UserName", name},
                {"Email", email}
            };

            JavaScriptSerializer js = new JavaScriptSerializer();
            string json = js.Serialize(keyValues);
            return json;
        }
    }
}

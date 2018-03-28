using System.Web.Script.Serialization;

public class jsonwhoisapi
{
    public WhoISParsed GetWhoISParsed(string vDomain)
    {
        try
        {
            string strAccountNumber = "";
            string strAPIKey = "";
            var request = System.Net.WebRequest.Create("https://jsonwhoisapi.com/api/v1/whois?identifier=" + HttpUtility.UrlEncode(vDomain)) as System.Net.HttpWebRequest;
            request.Method = "GET";
            request.ContentType = "application/json";
            string svcCredentials = Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes(strAccountNumber + ":" + strAPIKey));
            request.Headers.Add("authorization", "Basic " + svcCredentials);
            string strResponseContent;
            using (var response = request.GetResponse() as System.Net.HttpWebResponse)
            {
                using (var reader = new System.IO.StreamReader(response.GetResponseStream()))
                {
                    strResponseContent = reader.ReadToEnd();
                }
            }

            JavaScriptSerializer serializer = new JavaScriptSerializer;
            WhoISParsed oWhoIsParsed;
            oWhoIsParsed = serializer.Deserialize<WhoISParsed>(strResponseContent);
            return oWhoIsParsed.created;
        }
        catch (Exception ex)
        {
        }
    }
}


public class Table
    {
    }

    public class Registrar
    {
        public Table table { get; set; }
        public string id { get; set; }
        public object name { get; set; }
        public object email { get; set; }
        public object url { get; set; }
        public object phone { get; set; }
     }
    
    Public Class Contacts
    {
        Public Owner owner { get; set; }
        Public Admin admin { get; set; }
        Public Tech tech { get; set; }
    }


    public class WhoISParsed
    {
        public string name { get; set; }
        public object created { get; set; }
        public object changed { get; set; }
        public object expires { get; set; }
        public object dnssec { get; set; }
        public object registered { get; set; }
        public object status { get; set; }
        public IList<object> nameservers { get; set; }
        public object contacts { get; set; }
        public Registrar registrar { get; set; }
        public object throttled { get; set; }
    }
    
    Public Class Owner
    {
       public object handle { get; set; }
       public object type { get; set; }
       public string name { get; set; }
       public string organization { get; set; }
       public string email { get; set; }
       public string address { get; set; }
       public string zipcode { get; set; }
       public string city { get; set; }
       public string state { get; set; }
       public string country { get; set; }
       public string phone { get; set; }
       public string fax { get; set; }
       public object created { get; set; }
       public object changed { get; set; }
 }

    Public Class Admin
    {
       public object handle { get; set; }
       public object type { get; set; }
       public string name { get; set; }
       public string organization { get; set; }
       public string email { get; set; }
       public string address { get; set; }
       public string zipcode { get; set; }
       public string city { get; set; }
       public string state { get; set; }
       public string country { get; set; }
       public string phone { get; set; }
       public string fax { get; set; }
       public object created { get; set; }
       public object changed { get; set; }
   }

    Public Class Tech
    {
       public object handle { get; set; }
       public object type { get; set; }
       public string name { get; set; }
       public string organization { get; set; }
       public string email { get; set; }
       public string address { get; set; }
       public string zipcode { get; set; }
       public string city { get; set; }
       public string state { get; set; }
       public string country { get; set; }
       public string phone { get; set; }
       public string fax { get; set; }
       public object created { get; set; }
       public object changed { get; set; }
   }


    

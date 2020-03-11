using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using USPS_Web.Models;
using Microsoft.Xrm.Tooling.Connector;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;

namespace USPS_Web.Controllers
{
    public class CustomAddressController : ApiController
    {
        static string strConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MyCDSServer"].ToString();
        static CrmServiceClient svc = new CrmServiceClient(strConnectionString);

        public List<CustomAddress> Get()
        {
            List<CustomAddress> list = new List<CustomAddress>();
            QueryExpression queryCustomAddress = new QueryExpression("ss_customaddress");
            queryCustomAddress.ColumnSet.AllColumns = true;
            EntityCollection CustomAddressCols = svc.RetrieveMultiple(queryCustomAddress);
            foreach (Entity app in CustomAddressCols.Entities)
            {
                CustomAddress obj = new CustomAddress();
                if (app.Attributes["ss_name"].ToString() != null)
                {
                    obj.name = app.Attributes["ss_name"].ToString();
                }
                list.Add(obj);
            }
            return list;
        }
    }
}

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
    public class uspsDynamicsController : ApiController
    {
        static string strConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MyCDSServer"].ToString();
        static CrmServiceClient svc = new CrmServiceClient(strConnectionString);

        public List<Opportunity> Get()
        {
            List<Opportunity> list = new List<Opportunity>();
            QueryExpression queryOpportunity = new QueryExpression("opportunity");
            queryOpportunity.ColumnSet.AllColumns = true;
            EntityCollection opportunityCols = svc.RetrieveMultiple(queryOpportunity);
            foreach (Entity opp in opportunityCols.Entities)
            {
                Opportunity obj = new Opportunity();
                if (opp.Attributes["name"].ToString() != null)
                {
                    obj.name = opp.Attributes["name"].ToString();
                }
                list.Add(obj);
            }
            return list;
        }
    }
}

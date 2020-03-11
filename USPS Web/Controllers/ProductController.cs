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
    public class ProductController : ApiController
    {
        static string strConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MyCDSServer"].ToString();
        static CrmServiceClient svc = new CrmServiceClient(strConnectionString);

        public List<Product> Get()
        {
            List<Product> list = new List<Product>();
            QueryExpression queryProduct = new QueryExpression("product");
            queryProduct.ColumnSet.AllColumns = true;
            EntityCollection ProductCols = svc.RetrieveMultiple(queryProduct);
            foreach (Entity app in ProductCols.Entities)
            {
                Product obj = new Product();
                if (app.Attributes["name"].ToString() != null)
                {
                    obj.name = app.Attributes["name"].ToString();
                }
                list.Add(obj);
            }
            return list;
        }
    }
}

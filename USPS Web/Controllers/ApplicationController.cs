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
    public class ApplicationController : ApiController
    {
        static string strConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MyCDSServer"].ToString();
        static CrmServiceClient svc = new CrmServiceClient(strConnectionString);

        public List<Application> Get()
        {
            List<Application> list = new List<Application>();
            QueryExpression queryApplication = new QueryExpression("ss_application");
            queryApplication.ColumnSet.AllColumns = true;
            EntityCollection applicationCols = svc.RetrieveMultiple(queryApplication);
            foreach (Entity app in applicationCols.Entities)
            {
                Application obj = new Application();
                if (app.Attributes["ss_name"].ToString() != null)
                {
                    obj.name = app.Attributes["ss_name"].ToString();
                    obj.id =  app.Id;
                    obj.type = app.FormattedValues["ss_applicationtype"].ToString();
                    obj.createdon = app.Attributes["createdon"].ToString();
                }
                list.Add(obj);
            }
            return list;
        }
        //public List<Application> Post()
        //{
        //    Guid newGuid = Guid.Parse(int id, [FromBody]string value);
        //    svc.Update
        //    List<Application> list = new List<Application>();
        //    QueryExpression queryApplication = new QueryExpression("ss_application");
        //    queryApplication.ColumnSet.AllColumns = true;
        //    EntityCollection applicationCols = svc.RetrieveMultiple(queryApplication);
        //    foreach (Entity app in applicationCols.Entities)
        //    {
        //        Application obj = new Application();
        //        if (app.Attributes["ss_name"].ToString() != null)
        //        {
        //            obj.name = app.Attributes["ss_name"].ToString();
        //            obj.id = app.Id;
        //        }
        //        list.Add(obj);
        //    }
        //    return list;
        //}
        //public List<Application> Put()
        //{
        //    Guid newGuid = Guid.Parse(int id, [FromBody]string value);
        //    svc.Update
        //    List<Application> list = new List<Application>();
        //    QueryExpression queryApplication = new QueryExpression("ss_application");
        //    queryApplication.ColumnSet.AllColumns = true;
        //    EntityCollection applicationCols = svc.RetrieveMultiple(queryApplication);
        //    foreach (Entity app in applicationCols.Entities)
        //    {
        //        Application obj = new Application();
        //        if (app.Attributes["ss_name"].ToString() != null)
        //        {
        //            obj.name = app.Attributes["ss_name"].ToString();
        //            obj.id = app.Id;
        //            obj.type = app.FormattedValues["ss_applicationtype"].ToString();
        //            obj.destination = app.FormattedValues["ss_destinationaddress"].ToString();
        //        }
        //        list.Add(obj);
        //    }
        //    return list;
        //}


    }
}

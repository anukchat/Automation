using Pages.Contracts;
using System;

namespace API.Page.Repository
{
    //<summary>
    //Q: What is REST API?
    //A: Stands for Representational State Transfer, is an architectural style that defiens a set of constraints an properties based on HTTP
    //   Methods: GET,POST,PUT,DELETE,PATCH
    //Q: Essentials for REST request
    //A: Client,request,baseurl,endpoint,Method
    //Authentication- Session TokenID,Username/pwd,Request -JSON/XML, HTTP Method -CRUD,GET calls
    //URIs,headers and payload

    //</summary>
    public class APIBase : IBase
    {
        public void InitialSetup()
        {
            
        }
    }
}
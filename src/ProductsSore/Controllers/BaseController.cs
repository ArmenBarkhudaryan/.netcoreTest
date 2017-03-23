using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BusinessLayer;
using ProductsStore.Middleware;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductsStore.Controllers
{
    
    public class BaseController : Controller
    {
       public ProductsBL BusinessLayer = new  ProductsBL();
        public TokenProviderClass TokenProvider = TokenProviderClass.GetTokenProviderPipeline();
       
    }
}

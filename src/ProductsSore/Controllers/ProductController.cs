using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ProductsStore.ViewModel;
using Microsoft.AspNetCore.Authorization;
using CommonLayer;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductsStore.Controllers
{
    [Route("api/[controller]")]
   // [Authorize]
    public class ProductController : BaseController
    {
        // GET: api/values
        [Authorize(Roles = "admin")]
        [Route("[action]")]
        public List<ProductViewModel> GetAllProducts()
        {
            var d = HttpContext;

            List<ProductHistoryDM> list = BusinessLayer.GetAllProducts();
            List<ProductViewModel> ViewModel = new List<ProductViewModel>();

            foreach (var item in list)
            {
                ProductViewModel model = new ProductViewModel();
                model.ProductHistoryID = item.ProductHistoryID;
                model.Price = item.Price;
                model.CreationDate = item.CreationDate;
                model.ProductType = item.ProductType.Type;
                model.ProductTypeID = item.ProductType.ID;
                model.Manufacture.ID = item.Manufacturer.ID;
                model.Manufacture.Name = item.Manufacturer.Name;
                model.Product.ID = item.ProductModel.Id;
                model.Product.Name = item.ProductModel.Name;
                ViewModel.Add(model);
            }

            return ViewModel;
        }

        // GET api/values/5
        //[HttpGet("{id:int}")]
        //public List<ProductViewModel> Get(int id)
        //{
        //    List<ProductHistoryDM> model = BusinessLayer.GetProductsByID(id);
        //    List<ProductViewModel> viewModel = new List<ProductViewModel>();

        //    foreach (var item in model)
        //    {
        //        ProductViewModel mod = new ProductViewModel();
        //        mod.Price = item.Price;
        //        mod.CreationDate = item.CreationDate;
        //        mod.ProductHistoryID = item.ProductHistoryID;
        //        mod.Product.ID = item.ProductModel.Id;
        //        mod.Product.Name = item.ProductModel.Name;
        //        mod.ProductType = item.ProductType.Type;
        //        mod.ProductTypeID = item.ProductType.ID;
        //        mod.Manufacture.ID = item.Manufacturer.ID;
        //        mod.Manufacture.Name = item.Manufacturer.Name;
        //        viewModel.Add(mod);
        //    }

        //    return viewModel;
        //}

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] ProductViewModel ViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ProductHistoryDM model = new ProductHistoryDM();
                    model.Price = ViewModel.Price;
                    model.ProductType.ID = ViewModel.ProductTypeID;
                    model.ProductModel.Id = ViewModel.Product.ID;
                    model.Manufacturer.ID = ViewModel.Manufacture.ID;
                    BusinessLayer.AddProduct(model);
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
               
            }
            catch(Exception ex)
            {
                return null;
            }

        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

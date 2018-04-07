using Myshop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.DataAccess.InMemory
{
    public class ProductSectionRepository
    {

        //we add CRUD functions for Product section, the code is similar ad our prodct page
        ObjectCache cache = MemoryCache.Default;
        List<ProductSection> productsections;

        public ProductSectionRepository()
        {
            productsections = cache["productsections"] as List<ProductSection>;
            if (productsections == null)
            {
                productsections = new List<ProductSection>();
            }
        }

        public void Commit()
        {
            cache["productsections"] = productsections;
        }

        public void Insert(ProductSection p)
        {
            productsections.Add(p);
        }

        public void Update(ProductSection ProductSection)
        {
            ProductSection ProductSectionToUpdate = productsections.Find(p => p.Id == ProductSection.Id);

            if (ProductSectionToUpdate != null)
            {
                ProductSectionToUpdate = ProductSection;
            }
            else
            {
                throw new Exception("Product Section no found");
            }
        }

        public ProductSection Find(string Id)
        {
            ProductSection ProductSection = productsections.Find(p => p.Id == Id);

            if (ProductSection != null)
            {
                return ProductSection;
            }
            else
            {
                throw new Exception("Product Section no found");
            }
        }

        public IQueryable<ProductSection> Collection()
        {
            return productsections.AsQueryable();
        }

        public void Delete(string Id)
        {
            ProductSection ProductSectionToDelete = productsections.Find(p => p.Id == Id);

            if (ProductSectionToDelete != null)
            {
                productsections.Remove(ProductSectionToDelete);
            }
            else
            {
                throw new Exception("Product no found");
            }
        }
    }
}

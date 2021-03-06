﻿using Model.EF;
using Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
     public class ProductDao
    {
        OnlineShopDbContext db = new OnlineShopDbContext();
        public ProductDao()
        {
            this.db = db;
        }
        public List<Product> lstProduct()
        {
            return db.Products.ToList();
        }
        public List<Product> NewProducts(int top)
        {
            return db.Products.OrderByDescending(s=>s.CreatedDate).Take(top).ToList();
        }
        public List<ProductViewModel> ListByCategory(long categoryID, ref int totalRecord, int pageIndex=1, int pageSize=2)
        {
            totalRecord = db.Products.Where(s => s.CategoryId == categoryID).Count();
            var model = from a in db.Products
                        join b in db.ProductCategories
                           on a.CategoryId equals b.ID
                        select new ProductViewModel()
                        {
                            CateMetaTitle = b.MetaTitle,
                            CateName = b.Name,
                            CreatedDate = a.CreatedDate,
                            ID = a.ID,
                            Name = a.Name,
                            Image= a.Image,
                            MetaTitle = a.MetaTitle,
                            Price = a.Price,

                        };
             model.OrderByDescending(x=>x.CreatedDate).Skip((pageIndex - 1)* pageSize).Take(pageSize).ToList();
            return model.ToList();
        }
        
        public List<Product> ListFeatureProducts(int top)
        {
            return db.Products.Where(x => x.TopHot != null && x.TopHot > DateTime.Now).OrderByDescending(x => x.CreatedDate).Take(top).ToList();
        }
        public List<Product> ListRelatedProducts(long productId)
        {
            var product = db.Products.Find(productId);
            return db.Products.Where(x => x.ID != productId && x.CategoryId == product.CategoryId).ToList();
        }
        public Product ViewDetail(long id)
        {
            return db.Products.Find(id);
        }
    }
}

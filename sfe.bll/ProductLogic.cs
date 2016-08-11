﻿using sfe.dal;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sfe.bll
{
    public class ProductLogic
    {
        private static DataClassesDataContext db = Database.Instance;
        public static List<Product> Read()
        {
            try
            {
                return (from products in db.Products
                        where products.active == true
                        select products).ToList();
            }
            catch (Exception e)
            {
                EventLog.WriteEntry("sfe", e.StackTrace.ToString(), EventLogEntryType.Error);
                throw new ProductListNotFoundException("Product list not found");
            }
        }

        public static Product Read(int id)
        {
            try
            {
                return (from product in db.Products
                        where product.idProduct == id
                        select product).Single();
            }
            catch (Exception e)
            {
                EventLog.WriteEntry("sfe", e.StackTrace.ToString(), EventLogEntryType.Error);
                throw new ProductNotFoundException("Product not found");
            }
        }

        public static void Create(Product product)
        {
            try
            {
                db.Products.InsertOnSubmit(product);
                db.SubmitChanges();
            }
            catch (Exception e)
            {
                EventLog.WriteEntry("sfe", e.StackTrace.ToString(), EventLogEntryType.Error);
                throw new PostProductException("Error creating product");
            }
        }
    }
}

using Infosys.DBFirstCore.DataAccessLayer.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infosys.DBFirstCore.DataAccessLayer
{
    public class QuickKartRepository
    {
        private QuickKartDbContext context;

        public QuickKartRepository(QuickKartDbContext context)
        {
            this.context = context;
        }

        #region READ
        public List<Category> GetAllCategories()
        {
            //var categoriesList = (from category in context.Categories
            //                      orderby category.CategoryId
            //                      select category).ToList(); // Query syntax
            var categoriesList = context.Categories.OrderBy(c => c.CategoryId).ToList(); // Method syntax
            return categoriesList;
        }

        public List<Product> GetProductsOnCategoryId(byte categoryId)
        {
            List<Product> lstProducts = new List<Product>();
            try
            {
                lstProducts = context.Products.Where(p => p.CategoryId == categoryId).ToList();
            }
            catch (Exception)
            {
                lstProducts = null;
            }
            return lstProducts;
        }

        public Product FilterProducts(byte categoryId)
        {
            Product product = new Product();
            try
            {
                //product = context.Products.Where(p => p.CategoryId == categoryId).FirstOrDefault();

                product = context.Products.Where(p => p.CategoryId == categoryId)
                                     .OrderByDescending(p => p.Price)
                                     .LastOrDefault();
            }
            catch (Exception)
            {
                product = null;
                throw;
            }
            return product;
        }

        public List<Product> FilterProductsUsingLike(string pattern)
        {
            List<Product> lstProduct = new List<Product>();
            try
            {
                lstProduct = context.Products.Where(p => EF.Functions.Like(p.ProductName, pattern)).ToList();
            }
            catch (Exception)
            {
                lstProduct = null;
            }
            return lstProduct;
        }

        //Excercise
        public List<User> GetAllUsers()
        {
            var lstUsers = context.Users.OrderBy(u => u.DateOfBirth).ToList();
            return lstUsers;
        }
        #endregion

        #region CREATE
        public bool AddCategory(string categoryName)
        {
            bool status = false;
            Category category = new Category();
            category.CategoryName = categoryName;
            try
            {
                //context.Categories.Add(category);
                context.Add<Category>(category);
                int count = context.SaveChanges();
                Console.WriteLine("Number of records affected: " + count);
                status = true;
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }
        public bool AddProductsUsingAddRange(params Product[] products)
        {
            bool status = false;
            try
            {
                context.Products.AddRange(products);
                int count = context.SaveChanges();
                Console.WriteLine("Number of records affected: " + count);
                status = true;
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }

        public bool RegisterUser(string userPassword, string gender, string emailId, DateTime dateOfBirth, string address)
        {
            bool status = false;
            try
            {
                string temp = dateOfBirth.ToString("yyyy-MM-dd");
                DateOnly dateOnly = DateOnly.Parse(temp);

                User user = new User();
                user.UserPassword = userPassword;
                user.Gender = gender;
                user.EmailId = emailId;
                user.DateOfBirth = dateOnly;
                user.Address = address;
                context.Users.Add(user);
                int count = context.SaveChanges();
                Console.WriteLine("Number of records affected: " + count);
            }
            catch (Exception)
            {
                status = false;
                throw;
            }

            return status;
        }
        #endregion

        #region UPDATE
        public bool UpdateCategory(byte categoryId, string newCategoryName)
        {
            //Category category = context.Categories.Where(c => c.CategoryId == categoryId).FirstOrDefault();
            bool status = false;
            Category category = context.Categories.Find(categoryId);
            try
            {
                if (category != null)
                {
                    category.CategoryName = newCategoryName;
                    context.SaveChanges();
                    status = true;
                }
                else
                {
                    status = false;
                }
            }
            catch (Exception)
            {
                status = false;
                throw;
            }
            return status;
        }

        public int UpdateProduct(string productId, decimal price)
        {
            int status = -1;
            try
            {
                Product product = context.Products.Find(productId);
                product.Price = price;

                using (var newContext = new QuickKartDbContext())
                {
                    newContext.Products.Update(product);
                    newContext.SaveChanges();
                    status = 1;
                }

            }
            catch (Exception)
            {
                status = -99;
                throw;
            }
            return status;
        }

        public int UpdateProductsUsingUpdateRange(byte categoryId, int quantityProcured)
        {
            int status = -1;

            try
            {
                List<Product> productList = context.Products.Where(p => p.CategoryId == categoryId).ToList();
                foreach (var product in productList)
                {
                    product.QuantityAvailable += quantityProcured;
                }
                using (var newContext = new QuickKartDbContext())
                {
                    newContext.Products.UpdateRange(productList);
                    newContext.SaveChanges();
                    status = 1;
                }
            }
            catch (Exception)
            {
                status = -99;
                throw;
            }
            return status;
        }

        public bool UpdateUserPassword(string EmailId, string newUserPassword)
        {
            bool status = false;
            try
            {
                User user = context.Users.Where(u => u.EmailId == EmailId).FirstOrDefault();
                if (user != null)
                {
                    user.UserPassword = newUserPassword;
                    context.SaveChanges();
                    status = true;
                }
                else
                {
                    status = false;
                }
            }
            catch (Exception)
            {
                status = false;
                throw;
            }
            return status;
        }
        #endregion

        #region DELETE
        public bool DeleteProduct(string productId)
        {
            Product product = new Product();
            bool status = false;
            try
            {
                product = context.Products.Find(productId);
                if (product != null)
                {
                    context.Products.Remove(product);
                    context.SaveChanges();
                    status = true;
                }
                else
                {
                    status = false;
                }
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }

        public bool DeleteProductsUsingRemoveRange(string subString)
        {
            bool status = false;
            try
            {
                var deleteProducts = context.Products.Where(p => p.ProductName.Contains(subString));
                context.Products.RemoveRange(deleteProducts);
                context.SaveChanges();
                status = true;
            }
            catch (Exception ex)
            {
                status = false;
            }
            return status;
        }

        public bool DeleteUserDetails(string emailID)
        {
            bool status = false;
            //context.Users.Remove(context.Users.Find(emailID));
            User user = context.Users.Where(u => u.EmailId == emailID).FirstOrDefault();
            try
            {
                if (user != null)
                {
                    context.Users.Remove(user);
                    context.SaveChanges();
                    status = true;
                }
            }
            catch (Exception)
            {
                status = false;
                throw;
            }
            return status;
        }
        #endregion

        #region Call Stored Procedure
        public int AddCategoryDetailsUsingUSP(string categoryName, out byte categoryId)
        {
            categoryId = 0;
            int noOfRowsAffected = 0;
            int returnResult = 0;
            SqlParameter prmCategoryName = new SqlParameter("@CategoryName", categoryName);
            SqlParameter prmCategoryId = new SqlParameter("@CategoryId", System.Data.SqlDbType.TinyInt);
            prmCategoryId.Direction = System.Data.ParameterDirection.Output;
            SqlParameter prmReturnResult = new SqlParameter("@ReturnResult", System.Data.SqlDbType.Int);
            prmReturnResult.Direction = System.Data.ParameterDirection.Output;
            try
            {
                noOfRowsAffected = context.Database
                                .ExecuteSqlRaw("EXEC @ReturnResult = usp_AddCategory @CategoryName, @CategoryId OUT",
                                               prmReturnResult, prmCategoryName, prmCategoryId);
                returnResult = Convert.ToInt32(prmReturnResult.Value);

                categoryId = Convert.ToByte(prmCategoryId.Value);
            }
            catch (Exception ex)
            {
                categoryId = 0;
                noOfRowsAffected = -1;
                returnResult = -99;
            }
            return returnResult;
        }
        #endregion

        public List<ProductCategoryName> GetProductsUsingTVF(byte categoryId)
        {
            List<ProductCategoryName> lstProduct = new List<ProductCategoryName>();
            try
            {
                //SqlParameter prmCategoryId = new SqlParameter("@CategoryId", categoryId);
                //lstProduct = context.ProductCategoryNames.FromSqlRaw("SELECT * FROM ufn_GetProductCategoryDetails(@CategoryId)", 
                //                                        prmCategoryId).ToList();
                lstProduct = context.ProductCategoryNames
                    .FromSqlInterpolated($"SELECT * FROM ufn_GetProductCategoryDetails({categoryId})").ToList();
            }
            catch (Exception ex)
            {
                lstProduct = null;
            }
            return lstProduct;
        }

        public string GetNewProductId()
        {
            string productId = string.Empty;
            try
            {
                productId = (from s in context.Products
                             select QuickKartDbContext.GenerateNewProductId())
                             .FirstOrDefault();
            }
            catch (Exception ex)
            {
                productId = null;
            }
            return productId;
        }

        public bool CheckEmailId(string emailId)
        {
            bool result;
            try
            {
                result = (from p in context.Users
                          select QuickKartDbContext.ufn_CheckEmailId(emailId))
                          .FirstOrDefault();
            }
            catch (Exception ex)
            {
                result = false;
            }

            return result;
        }




    }
}

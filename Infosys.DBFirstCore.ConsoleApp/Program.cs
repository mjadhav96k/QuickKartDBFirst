using System;
using System.Net;
using System.Reflection;
using Infosys.DBFirstCore.DataAccessLayer;
using Infosys.DBFirstCore.DataAccessLayer.Models;
namespace Infosys.DBFirstCore.ConsoleApp
{
    public class Program
    {
        static QuickKartDbContext context;
        static QuickKartRepository repository;

        static Program()
        {
            context = new QuickKartDbContext();
            repository = new QuickKartRepository(context);
        }
        static void Main(string[] args)
        {
            #region READ
            //var categories = repository.GetAllCategories();
            //Console.WriteLine("----------------------------------");
            //Console.WriteLine("CategoryId\tCategoryName");
            //Console.WriteLine("----------------------------------");
            //foreach (var category in categories)
            //{
            //    Console.WriteLine("{0}\t\t{1}", category.CategoryId, category.CategoryName);
            //}

            ////////////////////////////////////////////////////////////////////////////////////////
            //byte categoryId = 1;
            //List<Product> lstProducts = repository.GetProductsOnCategoryId(categoryId);

            //if (lstProducts.Count == 0)
            //{
            //    Console.WriteLine("No products available under the category = " + categoryId);
            //}
            //else
            //{
            //    Console.WriteLine("{0,-15}{1,-30}{2,-15}{3,-10}{4}", "ProductId", "ProductName", "CategoryId", "Price", "QuantityAvailable");
            //    Console.WriteLine("---------------------------------------------------------------------------------------");
            //    foreach (var product in lstProducts)
            //    {
            //        Console.WriteLine("{0,-15}{1,-30}{2,-15}{3,-10}{4}", product.ProductId, product.ProductName, product.CategoryId, product.Price, product.QuantityAvailable);
            //    }
            //}

            ///////////////////////////////////////////////////////////////////////////////////////////
            //byte categoryId = 1;
            //Product product = repository.FilterProducts(categoryId);
            //if (product == null)
            //{
            //    Console.WriteLine("No product details available");
            //}
            //else
            //{
            //    Console.WriteLine("{0,-15}{1,-30}{2,-15}{3,-10}{4}", "ProductId", "ProductName", "CategoryId", "Price", "QuantityAvailable");
            //    Console.WriteLine("---------------------------------------------------------------------------------------");
            //    Console.WriteLine("{0,-15}{1,-30}{2,-15}{3,-10}{4}", product.ProductId, product.ProductName, product.CategoryId, product.Price, product.QuantityAvailable);
            //}
            //Console.WriteLine();

            //string pattern = "BMW%";
            //List<Product> lstProducts = repository.FilterProductsUsingLike(pattern);
            //if (lstProducts.Count == 0)
            //{
            //    Console.WriteLine("No products available with the = " + pattern);
            //}
            //else
            //{
            //    Console.WriteLine("{0,-15}{1,-30}{2,-15}{3,-10}{4}", "ProductId", "ProductName", "CategoryId", "Price", "QuantityAvailable");
            //    Console.WriteLine("---------------------------------------------------------------------------------------");
            //    foreach (var product in lstProducts)
            //    {
            //        Console.WriteLine("{0,-15}{1,-30}{2,-15}{3,-10}{4}", product.ProductId, product.ProductName, product.CategoryId, product.Price, product.QuantityAvailable);
            //    }
            //}
            //Console.WriteLine(); 

            //var userlist = repository.GetAllUsers();
            //Console.WriteLine("---------------------------------------------------------------------------------------------------------");
            //Console.WriteLine("{0,-30}{1,-20}{2,-10 }{3,-10}{4}", "EmailID", "UserPassword", "RoleId", "Gender", "DateOfBirth");
            //Console.WriteLine("---------------------------------------------------------------------------------------------------------");
            //foreach (var users in userlist)
            //{
            //    Console.WriteLine("{0,-30}{1,-20}{2,-10}{3,-10}{4}", users.EmailId, users.UserPassword, users.RoleId, users.Gender, users.DateOfBirth);
            //}
            #endregion

            #region CREATE
            ////////////////////////////////////////////////////////////////////////////
            //bool result = repository.AddCategory("Books");
            //if (result)
            //{
            //    Console.WriteLine("New category added successfully");
            //}
            //else
            //{
            //    Console.WriteLine("Something went wrong. Try again!");
            //}

            //////////////////////////////////////////////////////////////////////////////
            //Product productOne = new Product();
            //productOne.ProductId = "P158";
            //productOne.ProductName = "The Ship of Secrets - Geronimo Stilton";
            //productOne.CategoryId = 8;
            //productOne.Price = 450;
            //productOne.QuantityAvailable = 10;
            //Product productTwo = new Product();
            //productTwo.ProductId = "P159";
            //productTwo.ProductName = "101 Nursery Rhymes";
            //productTwo.CategoryId = 8;
            //productTwo.Price = 700;
            //productTwo.QuantityAvailable = 10;
            //bool result = repository.AddProductsUsingAddRange(productOne, productTwo);
            //if (result)
            //{
            //    Console.WriteLine("Product details added successfully!");
            //}
            //else
            //{
            //    Console.WriteLine("Some error occurred. Try again!!");
            //}

            ////////////////////////////////////////////////////////////////////////////

            //bool result = repository.RegisterUser("GEAHN@123", "F", "Meghan@gmail.com", Convert.ToDateTime("02-dec-1978"), "New avenue, Robster");
            //if (result)
            //{
            //    Console.WriteLine("New user details added successfully");
            //}
            //else
            //{
            //    Console.WriteLine("Add a new user failed");
            //} 
            #endregion

            #region UPDATE
            //Connected Scenario
            //bool result = repository.UpdateCategory(8, "Stationery");
            //if (result)
            //{
            //    Console.WriteLine("Category details updated successfully");
            //}
            //else
            //{
            //    Console.WriteLine("Something went wrong. Try again!");
            //}

            //Disconnected Scenario
            //int status = repository.UpdateProduct("P159", 1000);
            //if (status == 1)
            //{
            //    Console.WriteLine("Product price updated successfully!");
            //}
            //else
            //{
            //    Console.WriteLine("Some error occurred. Try again!!");
            //}

            //Update Multiple Records
            //int status = repository.UpdateProductsUsingUpdateRange(8, 10);
            //if (status == 1)
            //{
            //    Console.WriteLine("Products updated successfully!");
            //}
            //else
            //{
            //    Console.WriteLine("Some error occurred. Try again!!");
            //}

            //Excercise
            //bool result = repository.UpdateUserPassword("Meghan@gmail.com", "GEAHNM@1234");
            //if (result)
            //{
            //    Console.WriteLine("New user password updated successfully");
            //}
            //else
            //{
            //    Console.WriteLine("Something went wrong. Try again!");
            //} 
            #endregion

            #region DELETE
            //bool status = repository.DeleteProduct("P159");
            //if (status)
            //{
            //    Console.WriteLine("Product details deleted successfully!");
            //}
            //else
            //{
            //    Console.WriteLine("Some error occurred. Try again!!");
            //}

            //bool status = repository.DeleteProductsUsingRemoveRange("BMW");
            //if (status)
            //{
            //    Console.WriteLine("Products deleted successfully");
            //}
            //else
            //{
            //    Console.WriteLine("Some error occurred.Try again!!");
            //}

            //bool status = repository.DeleteUserDetails("mjm090972@gmail.com");
            //if (status)
            //{
            //    Console.WriteLine("User details deleted successfully!");
            //}
            //else
            //{
            //    Console.WriteLine("Some error occurred. Try again!!");
            //} 
            #endregion
        }
    }
}

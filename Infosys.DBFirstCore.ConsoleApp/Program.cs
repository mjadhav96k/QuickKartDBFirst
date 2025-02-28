using System;
using System.Net;
using System.Reflection;
using Infosys.DBFirstCore.DataAccessLayer;
using Infosys.DBFirstCore.DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Infosys.DBFirstCore.ConsoleApp;

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

        #region Entity State Within a context
        //Console.WriteLine("1. Entities retrieved using LINQ");
        //var firstCategory = context.Categories.First();
        //Console.WriteLine("\nCategoryId  : {0}\nCategoryName: {1}\n", firstCategory.CategoryId, firstCategory.CategoryName);
        //Console.WriteLine("State: {0}", context.Entry(firstCategory).State);
        //Console.WriteLine("-----------------------------------------------------\n");

        //Console.WriteLine("2. New entity object added to DbSet<Category>");
        //Category newCategory = new Category();
        //newCategory.CategoryName = "Furniture";
        //context.Categories.Add(newCategory);
        //Console.WriteLine("\nState: {0}", context.Entry(newCategory).State);
        //Console.WriteLine("-----------------------------------------------------\n");

        //Console.WriteLine("3. Existing entity property value changed");
        //byte categoryId = 8;
        //Category updateCategory = context.Categories.Find(categoryId);
        //updateCategory.CategoryName = "Stationery";
        //Console.WriteLine("\nState: {0}", context.Entry(updateCategory).State);
        //Console.WriteLine("-----------------------------------------------------\n");

        //Console.WriteLine("4. Existing entity removed from the DbSet<Category>");
        //categoryId = 9;
        //Category deleteCategory = context.Categories.Find(categoryId);
        //context.Categories.Remove(deleteCategory);
        //Console.WriteLine("\nState: {0}", context.Entry(deleteCategory).State);
        //Console.WriteLine("-----------------------------------------------------\n");

        //Console.WriteLine("5. Entity not tracked by existing context");
        //var detachedCategory = new Category();
        //detachedCategory.CategoryName = "Footwear";
        //using (var newContext = new QuickKartDbContext())
        //{
        //    Console.WriteLine("\nState before Add(): {0}", newContext.Entry(detachedCategory).State);
        //    newContext.Categories.Add(detachedCategory);
        //    Console.WriteLine("State after Add() : {0}", newContext.Entry(detachedCategory).State);
        //}

        ////context.SaveChanges(); 
        #endregion

        #region Track changes within the context class
        using (var context = new QuickKartDbContext())
        {
            //Console.WriteLine("------------------------------");
            //Console.WriteLine("          Unchanged           ");
            //Console.WriteLine("------------------------------");
            //var categoriesList = context.Categories
            //                            .OrderBy(x => x.CategoryId)
            //                            .Select(x => x)
            //                            .ToList();
            //Console.WriteLine("CategoryId\tCategoryName");
            //Console.WriteLine("------------------------------");
            //foreach (var category in categoriesList)
            //{
            //    Console.WriteLine("{0}\t\t{1}", category.CategoryId, category.CategoryName);
            //}
            //Console.WriteLine("---------------------------");
            //Console.WriteLine("          Added          ");
            //Console.WriteLine("---------------------------");
            //Category newCategory = new Category();
            //newCategory.CategoryName = "Cosmetics";
            //context.Categories.Add(newCategory);
            //TrackEntityStates(context.ChangeTracker.Entries());
            //Console.WriteLine("------------------------------");
            //Console.WriteLine("          Modified          ");
            //Console.WriteLine("------------------------------");
            //byte categoryId = 10;
            //Category updateCategory = context.Categories.Find(categoryId);
            //updateCategory.CategoryName = "Footwear";
            //TrackEntityStates(context.ChangeTracker.Entries());
            //Console.WriteLine("------------------------------");
            //Console.WriteLine("          Deleted          ");
            //Console.WriteLine("------------------------------");
            //categoryId = 8;
            //Category deleteCategory = context.Categories.Find(categoryId);
            //context.Categories.Remove(deleteCategory);
            //TrackEntityStates(context.ChangeTracker.Entries());
            //Console.WriteLine("------------------------------");
            //Console.WriteLine("          Detached          ");
            //Console.WriteLine("------------------------------");
            //var detachedCategory = new Category();
            //detachedCategory.CategoryName = "Gifts & Greetings";
            //using (var newContext = new QuickKartDbContext())
            //{
            //    Console.WriteLine("State before Add(): {0}\n", newContext.Entry(detachedCategory).State);
            //    newContext.Categories.Add(detachedCategory);
            //    TrackEntityStates(newContext.ChangeTracker.Entries());
            //}
        }

        #endregion

        #region Call Stored Procedure
        //byte categoryId = 0;
        //int returnResult = repository.AddCategoryDetailsUsingUSP("Footwear", out categoryId);
        //if (returnResult > 0)
        //{
        //    Console.WriteLine("Category details added successfully with CategoryId = " + categoryId);
        //}
        //else
        //{
        //    Console.WriteLine("Some error occurred. Try again!");
        //} 
        #endregion

        #region Call TVF
        byte categoryId = 1;
        var products = repository.GetProductsUsingTVF(categoryId);
        Console.WriteLine("{0, -12}{1, -30}{2}", "ProductId", "ProductName", "CategoryName");
        Console.WriteLine("------------------------------------------------------");
        if (products == null || products.Count == 0)
        {
            Console.WriteLine("No products available under the given category!");
        }
        else
        {
            foreach (var product in products)
            {
                Console.WriteLine("{0, -12}{1, -30}{2}", product.ProductId, product.ProductName, product.CategoryName);
            }
        }
        #endregion

        string productId = repository.GetNewProductId();
        Console.WriteLine("New ProductId = " + productId);
        Console.WriteLine();

        bool result = repository.CheckEmailId("Ivy@gmail.com");
        if (result)
        {
            Console.WriteLine("EMailId can be used to register new user!");
        }
        else
        {
            Console.WriteLine("EmailId exists! Please use a new EmailId!!");
        }
    }
    private static void TrackEntityStates(IEnumerable<EntityEntry> entries)
    {
        Console.WriteLine("--------------------------");
        Console.WriteLine("{0, -16}{1, -16}", "Entity", "State");
        Console.WriteLine("--------------------------");
        foreach (var entry in entries)
        {
            Console.WriteLine("{0, -16}{1, -16}", entry.Entity.GetType().Name, entry.State.ToString());
        }
        Console.WriteLine();
    }

}

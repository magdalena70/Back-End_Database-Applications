using NewsDB.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsDB.Client
{
    class ConcurrentUpdatesConsoleApp
    {
        public static void ConcurrentUpdates()
        {
            // Problem 2.Concurrent Updates (Console App) -

            // Step 1.At startup, the app should load from the DB the news text and print it on the console.
            var firstContext = new NewsDBContext();
            var firstConcurrentNews = firstContext.NewsItems.Find(1);
            Console.WriteLine("Text from DB: " + firstConcurrentNews.Content + "\n");

            // Step 2.After that, the app should enter a new value for the news text from the console.
            Console.Write("User-1, Enter the corrected text: ");
            firstConcurrentNews.Content = Console.ReadLine();
            Console.WriteLine();

            var secondContext = new NewsDBContext();
            var secondConcurrentNews = secondContext.NewsItems.Find(1);
            Console.Write("User-2, Enter the corrected text: ");
            secondConcurrentNews.Content = Console.ReadLine();
            Console.WriteLine();

            // Step 3.After entering a new value, the app should try to save it to the DB.
            // In case of success (no conflicting updates), the app should say 
            // that the changes were saved and should finish its work.
            // In case of concurrent update conflict, the app should display 
            // an error message, should display the new (changed) text from the DB and should go to Step 2.
            firstContext.SaveChanges(); // first user

            Console.WriteLine(("Changes successfully saved in the DB.\n").ToUpper());
            Console.WriteLine("Text from DB after first changes: " +
                firstConcurrentNews.Content);
            try
            {
                secondContext.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                Console.WriteLine("Concurrent Update Conflict!" + ex.Message);
                Console.WriteLine("Text from DB: " +
                    firstConcurrentNews.Content +
                    "\n\nUser-2, Enter the corrected text:");
                firstConcurrentNews.Content = Console.ReadLine();
                Console.WriteLine(("\nChanges successfully saved in the DB.\n").ToUpper());
                Console.WriteLine("Text from DB after second changes: " +
                firstConcurrentNews.Content);
            }
            firstContext.SaveChanges();
        }
    }
}

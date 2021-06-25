﻿using System;

namespace LabaWork121
{
    class Lab121
    {
        static void Main(string[] args)
        {
            // 8) declare 2 objects. Use default and paremeter constructors
            LibraryUser user1 = new LibraryUser(), user2 = new LibraryUser("Maria", "Ivanenko", "+380447777777");
            Console.WriteLine($"User1: {user1.FirstName} {user1.LastName}, ID: {user1.ID}");
            Console.WriteLine($"User2: {user2.FirstName} {user2.LastName}, ID: {user2.ID}");

            // 9) do operations with books for all users: run all methods for both objects
            Console.WriteLine("--User 1: add Harry Potter");
            user1.BookAdd("Harry Potter");
            Console.WriteLine("--User 2: add Sherlock Holmes");
            user2.BookAdd("Sherlock Holmes");
            Console.WriteLine($"--user1.BooksCount = {user1.BooksCount()}; user2.BooksCount {user2.BooksCount()}");
            Console.WriteLine("--user2 :");
            Console.WriteLine("Add Kobzar");
            user2.BookAdd("Kobzar");
            Console.WriteLine("--user2.BooksCount " + user2.BooksCount());
            Console.WriteLine("Add Dorian Gray");
            user2.BookAdd("Dorian Gray");
            Console.WriteLine("--user2.BooksCount " + user2.BooksCount());
            Console.WriteLine("--user2 books " + user2[0] + "\n" + user2[1]);
            Console.WriteLine("--Remove Sherlock Holmes");
            user2.BookRemove("Sherlock Holmes");
            Console.WriteLine("--user2.BooksCount " + user2.BooksCount());

        }
    }
}

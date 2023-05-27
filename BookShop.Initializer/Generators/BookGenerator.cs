using BookShop.Models.Enums;

namespace BookShop.Initializer.Generators
{
    using BookShop.Models;
    using System;
    using System.Globalization;

    class BookGenerator
    {
        #region Book Description
        private static string bookDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, " +
            "sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. " +
            "Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris " +
            "nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit " +
            "in voluptate velit esse cillum dolore eu fugiat nulla pariatur. " +
            "Excepteur sint occaecat cupidatat non proident, " +
            "sunt in culpa qui officia deserunt mollit anim id est laborum.";
        #endregion

        internal static Book[] CreateBooks()
        {
            string[] booksInput = new string[]
            {
                //Edition ReleaseDate Copies Price AgeRestriction Title
                "1 20/01/1998 27274 15.31 2 Absalom",
                "0 14/09/1998 16159 35.56 0 After Many a Summer Dies the Swan",
                "0 13/03/1999 29025 23.71 0 Ah",
                "2 12/3/1993 9998 5.26 2 Wilderness!",
                "2 22/10/2014 18832 5.69 2 Alien CornÂ (play)",
                "0 18/02/2003 28741 34.56 2 The Alien CornÂ (short story)",
                "1 11/10/1991 20471 7.18 1 All Passion Spent",
                "2 29/03/1996 9457 45.6 0 All the King's Men",
                "2 30/11/2000 17327 14.99 0 Alone on a Wide",
                "0 23/04/1998 3226 24.37 1 Wide Sea",
                "1 8/3/1996 6171 34.64 2 An Acceptable Time",
                "2 7/9/2005 10049 38.51 1 Antic Hay",
                "1 10/10/1996 21765 3.3 0 An Evil Cradling",
                "0 24/01/2001 2408 24.4 0 Arms and the Man",
                "1 25/04/1992 2997 25.81 2 As I Lay Dying",
                "1 25/09/2006 29543 20.21 2 A Time to Kill",
                "2 28/10/2011 4893 18.01 0 Behold the Man",
                "1 23/08/2012 8159 23.83 2 Beneath the Bleeding",
                "2 17/05/2006 24103 45.45 2 Beyond the Mexique Bay",
                "0 25/03/2001 22304 16.68 1 Blithe Spirit",
                "0 4/5/2007 28137 28.97 2 Blood's a Rover",
                "2 3/3/1999 20946 9.76 0 Blue Remembered Earth",
                "0 27/07/2005 9177 37.17 2 Blue Remembered Hills",
                "1 29/10/2013 17688 19.51 0 Bonjour Tristesse",
                "0 6/5/2015 26819 5.63 1 Brandy of the Damned",
                "2 5/7/1987 4894 3.86 1 Bury My Heart at Wounded Knee",
                "1 5/5/2002 211 30.66 0 Butter In a Lordly Dish",
                "2 28/10/2010 28396 14.15 0 By Grand Central Station I Sat Down and Wept",
                "2 29/05/2002 15170 37.47 1 Cabbages and Kings",
                "1 28/01/2010 20513 3.32 0 Carrion Comfort",
                "0 3/12/1991 16585 15.78 2 A Catskill Eagle",
                "0 20/07/1990 14166 23.87 0 Clouds of Witness",
                "1 18/06/1993 29606 40.23 0 A Confederacy of Dunces",
                "0 6/11/1990 22390 46.43 2 Consider Phlebas",
                "1 21/07/1987 19292 30.89 0 Consider the Lilies",
                "1 28/10/2000 12346 40.23 1 Cover Her Face"
            };

            int bookCount = booksInput.Length;

            Category[] categories = CategoryGenerator.CreateCategories();

            Author[] authors = AuthorGenerator.CreateAuthors();

            Book[] books = new Book[bookCount];

            for (int i = 0; i < bookCount; i++)
            {
                string[] bookTokens = booksInput[i].Split();

                int edition = int.Parse(bookTokens[0]);
                DateTime releaseDate = DateTime.ParseExact(bookTokens[1], "d/M/yyyy", CultureInfo.InvariantCulture);
                int copies = int.Parse(bookTokens[2]);
                decimal price = decimal.Parse(bookTokens[3]);
                int ageRestriction = int.Parse(bookTokens[4]);
                string title = String.Join(" ", bookTokens, 5, bookTokens.Length - 5);
                Category category = categories[i / 10];
                Author author = authors[i / 5];

                Book book = new Book()
                {
                    Title = title,
                    ReleaseDate = releaseDate,
                    Description = bookDescription,
                    EditionType = (EditionType)edition,
                    Price = price,
                    Copies = copies,
                    AgeRestriction = (AgeRestriction)ageRestriction,
                    Author = author,
                };

                BookCategory bookCategory = new BookCategory()
                {
                    Category = category,
                    Book = book
                };

                book.BookCategories.Add(bookCategory);

                books[i] = book;
            }

            return books;
        }
    }
}

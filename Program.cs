using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop
{
    
    class Program
    {
        static void Main(string[] args)
        {
            Book book1 = new Book("C++", 20000);
            Book book2 = new Book("JAVA", 25000);
            Book book3 = new Book("KOTLIN", 30000);

            BookShop shop = new BookShop("Kitoblar olami", 1000000);
           
            bool result;
            int result1;

            result1 = shop.GetMoney();
            Console.WriteLine(result1);

            result=shop.HasBook();
            Console.WriteLine(result);

            result=shop.HasBook(book1);
            Console.WriteLine(result);

            result1=shop.BuyBook(book1, 40);
            Console.WriteLine(result1);

            result1=shop.SellBook(book1);
            Console.WriteLine(result1);

            //shop.getMoney();
            //shop.getMoney();

            result1=shop.BuyBook(book2, 20);
            Console.WriteLine(result1);

            result=shop.HasBook();
            Console.WriteLine(result);

            result=shop.HasBook(book1);
            Console.WriteLine(result);

            result1=shop.SellBook(book1, 1);
            Console.WriteLine(result1);

            result1=shop.SellBook(book3, 1);
            Console.WriteLine(result1);


            result1=shop.GetMoney();
            Console.WriteLine(result1);
            

            result1=shop.GetCount(book1);
            Console.WriteLine(result1);

            result1=shop.GetCount();
            Console.WriteLine(result1);

           Console.WriteLine(shop.GetBookShopName());
          
             Console.ReadKey();        
        }
         
    }
    class BookShop
    {
       
        private  int _money;
        private string _name;
        public int _count=0;
        private Dictionary<Book, int> _books;
        public BookShop(string name, int money)
        {
           _money  = money;
           _name  = name;
           _books = new Dictionary<Book, int>();

        }

        public bool HasBook()
        {
            return _books.Keys.Count > 0;
        }


        public bool HasBook(Book book)
        {
            return _books.ContainsKey(book);
        }

        public int SellBook(Book book, int count=1)
        {
            if (!_books.ContainsKey(book))
                return 0;


            int countOfBook=_books[book];
             if(countOfBook>=count)
            {
             _books[book]=countOfBook-count;
             _count -= count;
             _money += count * book.Price;
             return count;
            
             
            }
             _count -= countOfBook;
            _money += countOfBook * book.Price;
            _books[book] = 0;
            return countOfBook;

        }

        
        public int BuyBook(Book book, int count)
        {
            if (_money > book.Price * count)
            {
                _count += count;
                _money -= book.Price * count;
                AddBooks(book, count);
                     return count; 

            }

            int buyedBook = _money / book.Price;
            _count += buyedBook;
             _money -= book.Price * buyedBook;
             AddBooks(book, buyedBook);
             return buyedBook;

        }

        public void AddBooks(Book book, int count)
        {
            if (_books.ContainsKey(book))
                _books[book] += count;

            else
                _books.Add(book, count);
        }

        public int GetMoney()
        {
            return _money;
        }

        public int GetCount(Book book)
        {
            return _books[book];
        }


        public int GetCount()
        {
            return _count;
        }

        public string GetBookShopName()
        {
            return _name;
        }

    }
    class Book
    {
        public int Price {get; set;}
        public string Name {get; set;}
        public Book(string name, int price)
        {
            Name = name;
            Price=price;
          
        }
      
       

    }
    
}



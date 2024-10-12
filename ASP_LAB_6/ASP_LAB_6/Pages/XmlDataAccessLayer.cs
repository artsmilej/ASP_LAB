using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

public class XmlDataAccessLayer
{
    private readonly string _filePath;

    public XmlDataAccessLayer(string filePath)
    {
        
        _filePath = Path.Combine(Directory.GetCurrentDirectory(), "Data", filePath);
    }

   
    public List<Book> GetBooks()
    {
        if (!File.Exists(_filePath))
        {
            throw new FileNotFoundException("Файл не знайдено", _filePath);
        }

        XDocument doc = XDocument.Load(_filePath);
        var books = new List<Book>();

        foreach (var element in doc.Descendants("Book"))
        {
            decimal price;
            decimal.TryParse(element.Element("Price")?.Value, out price);

            books.Add(new Book
            {
                Title = element.Element("Title")?.Value,
                Author = element.Element("Author")?.Value,
                Genre = element.Element("Genre")?.Value,
                Price = price, 
                WritingDate = DateTime.Parse(element.Element("WritingDate")?.Value)
            });
        }

        return books;
    }

    
    public void AddBook(Book book)
    {
        XDocument doc;

   
        if (File.Exists(_filePath))
        {
            doc = XDocument.Load(_filePath);
        }
        else
        {
            doc = new XDocument(new XElement("Books"));
        }

      
        doc.Root.Add(new XElement("Book",
            new XElement("Title", book.Title),
            new XElement("Author", book.Author),
            new XElement("Genre", book.Genre),
            new XElement("Price", book.Price),
            new XElement("WritingDate", book.WritingDate.ToString("yyyy-MM-dd"))
        ));

    
        doc.Save(_filePath);
    }

    
    public void RemoveBook(string title)
    {
      
        if (!File.Exists(_filePath))
        {
            throw new FileNotFoundException("Файл не знайдено", _filePath);
        }

        XDocument doc = XDocument.Load(_filePath);
        var bookToRemove = doc.Descendants("Book")
            .FirstOrDefault(b => b.Element("Title")?.Value == title);

        if (bookToRemove != null)
        {
            bookToRemove.Remove();
            doc.Save(_filePath);
        }
    }
}


public class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public string Genre { get; set; }
    public decimal Price { get; set; }
    public DateTime WritingDate { get; set; }
}
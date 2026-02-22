using System;
using System.Text.Json.Serialization;

internal class Contact
{
    private static int _idCounter = 0;

    public int Id { get; set; }
    public string Name { get; set; } = "";  
    public string Phone { get; set; } = "";
    public string Email { get; set; } = "";
    public DateTime CreationDate { get; set; }

    public Contact() { }

    public Contact(string name, string email, string phone)
    {
        Id = ++_idCounter;
        Name = name;
        Email = email;
        Phone = phone;
        CreationDate = DateTime.Now;
    }

    public override string ToString()
    {
        return $"Id: {Id}, Name: {Name}, Phone: {Phone}, Email: {Email}, Created: {CreationDate}";
    }

    public static void SetIdCounter(int lastId)
    {
        _idCounter = lastId;
    }
}
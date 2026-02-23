# Modern Contact Indexing System (C# CLI)

A simple command-line **Contact Management System** in C# with JSON storage.  
Allows adding, editing, deleting, viewing, listing, and searching contacts.

---

## Features

- Add, edit, delete, and view contacts  
- List all contacts  
- Search contacts by name  
- Filter contacts by creation date  
- Persistent storage using JSON (`contacts.json`)  
- Unique ID and automatic creation date for each contact  

---

## Project Structure
Models/
Contact.cs
Services/
ContactManager.cs
Storage/
IStorage.cs
FileStorage.cs
UI/
Menu.cs
Application/
Application.cs
Program.cs

---

## How to Run

1. Install **.NET 6.0+ SDK**  
2. Clone the repository  
3. Build: `dotnet build`  
4. Run: `dotnet run`  
5. Follow the CLI menu to manage contacts

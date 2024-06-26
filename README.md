Microsoft Visual Studio 2022 Blazor Web App template and .Net 8 with rendering. 

Database access and rendering has been for me a tricky one. How to access database on WebAssembly or Server when rendering takes place on WebAssembly or Server?

One solution is to add HttpClient and Bookservice everywhere and on server side add controller BookController. BookController is reached from Client side when needed depending on if rendering takes place on WebAssembly.

BookController uses "DataContext context" instead of "BookService" on server side 20240507. IBookService is on .Shared third library project.

And I may give back a little to community making this GitHub repository public.

SimpleBookCatalogWithControllers

Here is a simple Book Catalog (as shown by CodeGanesh) using controllers (as shown by Patrick God). Database is SQLite.

Create a new project in Visual Studio and choose Blazor Web App, .Net 8, Auto (Server and WebAssembly).
Add a new project of type Library.

Add HttpClient both on server side and client side.

BookService.cs is different on server side and client side.

Register services on server and client side.

Install Design, Sqlite, Tools on server side. Add-migration and update-database works.

Helpful videos of Entity Framework Core in .NET 8 on YouTube:
https://www.youtube.com/watch?v=w8imy7LT9zY&t=3190s by Patrick God. Thank you.
https://www.youtube.com/watch?v=jw-udNnMgaE&t=10s by CodeGanesh. Thank you.

Late update 20240507:

Books.razor @attribute [StreamRendering].

AddBook.razor @rendermode InteractiveServer.

EditBook.razor @rendermode InteractiveServer.

DeleteBook.razor @rendermode InteractiveServer.

BookService is still needed on Server side.

With helpful regards Timo Kinnunen

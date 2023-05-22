<h2>MYUPDZ</h2>

This project demonstrates a simple implementation of clean architecture using .NET Core with a PostgreSQL database.

<h2>Migration Instructions</h2>

To perform a migration, follow these steps:

Open the command line or terminal.
Navigate to the project root directory.
Run the following command:
css
Copy code
dotnet ef migrations add "Name-of-migration" --project src\MYUPDZ.Infrastructure --startup-project src\MYUPDZ.Api --output-dir Persistence\Migrations
Replace "Name-of-migration" with a descriptive name for your migration.

By executing the above command, the migration will be generated and saved in the Persistence\Migrations directory of the MYUPDZ.Infrastructure project.

Feel free to explore the code and customize it to suit your needs.


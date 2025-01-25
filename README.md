#Tips for Successfully Working on This Project
##Update Connection String in appsettings.json:

##Ensure that the connection string in your appsettings.json file is correctly configured to point to your target machine or database environment. This is crucial for establishing the correct connection between your application and the database.
##Migrate Database Using Entity Framework Core:

##This project uses Entity Framework (EF) Core for database management. Before running the project for the first time, ensure that you perform a database migration to apply the latest schema changes. Use the following commands to update the database:
##dotnet ef migrations add <MigrationName>
##dotnet ef database update
##Seeding the Super Admin on First Run:


##admin credentials:
  ##User Name: Admin
  ##Password:Admin@123

###Upon the first execution of the project, there is a method to seed the system with a super admin account. This allows you to access the system and manage users. Please ensure that this seeding process is implemented and executed properly during the first startup to avoid any login issues.


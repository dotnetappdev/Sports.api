Skip to content
You said:
elease fix  the grammar and spelling of this 
Welcome to the api to get started please adjust the configs in 

1 Sports.api to point to your sql server instance
Create a blank database called SportsAPI and change
the connection string in Sports.api to pointto it and username
and password and server name

2 Then do the same for Sports.DataImport this is how we are 
going to import the data from the url. Change the appsettings 
here also to point to your sql server instance and the same db you created in step 1

![alt text](assests/import.png)

3 Open the package manager console once your settings have changed.
In Visual Studio and run the following commands be in the directory 

you can check via running pwd command then cd into it 

Sports.Infrastructure

![alt text](assests/import2.png)

4 Delete the migration folder in Sports.Infrastructure 
Called Data\Migrations remove the entire folder.

5 Then run the following command in the package manager console

	dotnet ef migrations add firstMigrations  --output-dir Data/Migrations --context ApplicationDbContext
![alt text](assests/import3.png)

This will create the migrations folder again and if you look 
at your sql server instace you will see the tables created.

6 Now the migrations are created update the database by running the following command in the package manager console

dotnet ef database update  
![alt text](assests/import4.png)

7 Now that that is done you can run the Sports.DataImport project let it complete.

This will import the data from the url into your database.

Once  that is done you can run the Sports.api project and it will be able to access the data.
And you can use the endpoints to get the data.

![alt text](assests/import5.png)
 
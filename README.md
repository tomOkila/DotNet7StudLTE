# DotNet7StudLTE
ASP.NET Core Complete Student CRUD Without Entity Framework - .NET 7
* Hello and Thank You for purchasing this project about creating a simple CRUD using .NET7 and without Entity Framework 
* Tools Required.
    - Visual Studio 2022
    - SQL Server Management Studio	Version:19.1.56.0 or later
    - SQL Server 2022 Express(It is a free version)

Below is the procedure for running the project
* Restore the database Student extracted from Database- Student.zip file to an installed MSSQL server instance with the details as specified above.
* Extract the CRUD application and open it in Visual Studio 2022 with the name DotNet7StudLTE.zip file
* Once the project is opened change the database connections in appsettings.json  to the one you have specified in the location where you restored your database.
* The database connection string to be changed in the json file is as below:

"DbConnector": "Data Source=SQLSERVERSAMPLE;Persist Security Info=True;User ID=sa;Password=XXXXXXXXXXX;Initial Catalog=Student; TrustServerCertificate=True;Encrypt=false"

* Once this is done rebuild the project to ensure there are no errors then run the project to view the status in the browser.


* After the  website has loaded, login to the application using the credentials as specified below:
    Email: admin@developercrucible.com
    Password: 123456

* With everything set up correctly, you should be able to reach the dashboard as shown in the attached screen-screenshot and be able to explore other functionalities

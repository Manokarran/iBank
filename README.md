# iBank

Summary:
This solution addresses one of the tasks where I have used .Net Core with EF Core 2, and using Onion architecture, Automapper, dependancy resolution, repository pattern.

Task is to “Design and build an API with supporting database schema that can provide access to
customer accounts and respective transaction history.
This is the technical document which explains how to set-up and use iBankApp solution which address this business problem. 

Functionality:
iBankApp solution structures the below customer data and it provides a list of APIs exposing the customer information in a different format.
1.	Customer Details
2.	Account Information
3.	Customer Transaction Details

Outstanding Items:
1.	Exception handling & Logging
2.	Implementation of Authentication
3.	Integration Test project

Technology & Tools Used:
1.	.Net Core 2
2.	Entity Framework Core 2
3.	SQL Server
4.  Visual Studio 2017
5.	Postman to test the API

Patterns Used:
1.	Repository & Unit of Work
2.	Auto Mapper
3.	Onion Architecture

Set-Up Guide:
1.	Download the project “iBankApp”
2.	Open the solution “iBankApp.sln”
3.	Under the “Application” logical folder, IBankApp.API project, below files can be found:

Please change the connection string from
"iBankConnection": "Data Source=YOUR SERVER NAME; Initial Catalog=iBank; Integrated Security=True;Connect Timeout=30"
  a.	appsettings.Development.json
  b.	appsettings.json
Note :  YOUR SERVER NAME :  Provide your SQL server  name.
Also, please change the connection string if you are not using windows authentication.
4.	Please set the project IBankApp.API as start-up project
You will have multiple ways to start the project:
  a.	By starting IIS Express
  b.	By selecting IBankApp.API self-hosted
(I have configured http://localhost:65413/ as default url.
You can change it from “../iBankApp/IBankApp.API/Properties/” and in “launchSettings.json” file.

5.	It launches default controller – just to check its able to connect
6.	First time when it launches, the Startup.cs file will create the database in the above provided SQL connection string and also inserts sample data.
Note: It does only once.
7.	In case of any problem in creating DB, please comment out the below code in startup.cs from “iBankApp.API”
//  NOTE: this must go at the end of Configure
            var serviceScopeFactory = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>();
            using (var serviceScope = serviceScopeFactory.CreateScope())
            {
                var dbContext = serviceScope.ServiceProvider.GetService<iBankAppContext>();
                dbContext.Database.EnsureCreated();
                new iBankDataSetup(dbContext).SetUpData();
            }
And please use the SQL script which I have provided in the email before running the API.
8.	You can test the API from postman once the application is launched.

 
 API Links			
1	http://localhost:65413/api/iBank/customer/	-->List out all customers	 
2	http://localhost:65413/api/iBank/customer/2	-->List out the given customer	 
3	http://localhost:65413/api/iBank/customer/2/IncludeAccounts	-->List the given Customer with Account details	 
4	http://localhost:65413/api/iBank/customer/2/IncludeTransactions -->List all given customer Transactions	 


 

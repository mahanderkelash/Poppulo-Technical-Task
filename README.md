# Poppulo-Technical-Task
Poppulo Technical Task

Mahander Kelash , mahanderlanghani@gmail.com


Framework Used:
Framework used to complete this task is .net core, the api controller and controller is made using .net core and for database I used Microsoft SQL Server. 

Installation of Application
This application is a web application that is built using .net core framework, to  run this application you need following:
1.	Visual Studio 2013+(2017 preferred) 
2.	Microsoft Sql Server.

Following are the steps to run application:
1.	Download/clone  application from github (https://github.com/mahanderkelash/Poppulo-Technical-Task). 
2.	Open the Application in Visual Studio
3.	Go to appsetting.json file and change the connection string to your own sql server connection string.
4.	In Visual Studio go to tools-> Nuget Package Manager -> Package Manager Console. Enter Following line of script into Package Manager Console and hit enter.

a. add-migration namexyz
b. Update database.


5.	Now your database is created and compile and run the application.


Structure of the Application
This application is a MVC application so it contains following items
1.	InventoryItem and Category Model classes.
2.	An api controller for Inventory Item.
3.	A controller for inventory items.
4.	A repository (inventoryitemrepository) to separate the main/business logic from controllers and also for dependency injection and for system testability.
5.	And Views for Inventory Item and category.

Persistence Level
Since I am using Entity framework there are two scenario in when persisting  an entity to the database, one is connected and other one is disconnected.
In this connected scenario is used where context is created one time and used for saving and retrieving  the entities for the application life time.
 

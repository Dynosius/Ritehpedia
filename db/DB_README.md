HOW TO IMPORT DATABASE:

The tool you need installed is Microsoft SQL Server Management Studio 2008 or after (SQL EXPRESS will do!).

After downloading the .bacpac file, open SQL Server Management Studio, connect through Windows authentication to either (yourpcname) or (yourpcname\SQLEXPRESS), depending  
on the version of your software.

Then you need to right click on Databases, and select the option "Import Data Tier Application", after which you will select the "ritehpedia.bacpac" file  
and import it to your database as "ritehpedia" (IMPORTANT!)


If your server is called (yourpcname), then you will need to change the connection string in Web.config file, and put the value of "Data server" to "Data server=(local)"  
instead of (local\SQLEXPRESS)
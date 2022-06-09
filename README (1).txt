Web-Holy

~~~~~~~~~~~~~~~~~~~
Gabriel Levin 317618346
Tal Ohayon 205597701
Yuval Avitan 319066007
Refael Robinov 311374193
~~~~~~~~~~~~~~~~~~~~~~~~

A Web App that can be using for Synagogue and view data for religion

.net  framework c# mvc core 5.0.
~~~~~~~~~~~~~~~~~~~~~~~~

Program Prerequisites:

Git 

Microsoft Visual Studio 2019 

Jenkies User 

heroku user

Microsoft SQL Server Management Studio 18


~~~~~~~~~~~~~~~~~~~~~~~~
Build steps:

Set up

run git init

run git clone https://github.com/Project-Management-SCE/PM2022_TEAM_28.git

run pip install -r requirements.txt

change the SqlLink on appsettings.json To your database
do update-database in the Package Manager Console
Ctrl+Shift+b to build the Project
Ctrl+F5 to run the Project

if you want to uplode the project ' use the Jenkies file and the Hourko 

~~~~~~~~~~~~~~~~~~~~~~~~
Test steps:

click on the Test file and start Test
~~~~~~~~~~~~~~~~~~~~~~~~


Cover steps

  dotnet test –collect:”XPlat Code Coverage”

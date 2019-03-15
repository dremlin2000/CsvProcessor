The following commands should be executed in command prompt (cmd.exe) in CsvProcessor.Repository folder

How to add a new migration:
	dotnet ef migrations add InitialCreate --startup-project ..\CsvProcessor.ConsoleApp

How to apply a new migration into database:
	dotnet ef database update --startup-project ..\CsvProcessor.ConsoleApp

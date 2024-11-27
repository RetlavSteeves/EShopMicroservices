dotnet ef migrations add InitialCreate -o Data/Migrations -p Ordering.Infrastructure.csproj -s ../Ordering.API  
dotnet-grpc add-file

This is not a question, just to inform to use following command if you are using dotnet cli command to update database:

dotnet ef database update -p Ordering.Infrastructure -s Ordering.API

I assume you are using following command to generate the migrations code:

dotnet ef migrations add InitialCreate -o Data/Migrations -p Ordering.Infrastructure -s Ordering.API
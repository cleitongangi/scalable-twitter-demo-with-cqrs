# scalable-twitter-demo-with-cqrs
A demo scalable application as twitter using CQRS, MediatR, RabbitMQ and Redis (for studies purposes only)


To add EF Migrations
dotnet ef migrations add InitialCreate --startup-project "./src/TwitterDemo.API/TwitterDemo.API.csproj" --context WriteDbContext --output-dir Migrations --project "./src/TwitterDemo.Infra.Data.Write/TwitterDemo.Infra.Data.Write.csproj"
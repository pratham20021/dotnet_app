var builder = WebApplication.CreateBuilder(args);
builder.WebHost.UseUrls("http://0.0.0.0:5000");

var app = builder.Build();

app.MapGet("/", () => "Welcome to .NET App");

app.MapGet("/about", () => "This is a simple .NET application");

app.MapGet("/api/data", () => new[]
{
    new { id = 1, name = "Alice", role = "Developer" },
    new { id = 2, name = "Bob",   role = "Designer"   },
    new { id = 3, name = "Carol", role = "Manager"    }
});

app.Run();

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages(); //html
var app = builder.Build();

app.UseStaticFiles(); // ���� ������ ���  

app.MapGet("/", () => "Hello World!");

app.Run();

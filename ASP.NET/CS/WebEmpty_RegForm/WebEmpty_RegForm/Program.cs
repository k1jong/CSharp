var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages(); //html
var app = builder.Build();

app.UseStaticFiles(); // 정적 페이지 사용  

app.MapGet("/", () => "Hello World!");

app.Run();

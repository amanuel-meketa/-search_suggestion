using search_suggestion.application.Contracts.Search;
using search_suggestion.application.Service.Search;
using System.Reflection;
using System.Threading.RateLimiting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
AddRateLimiter(builder.Services);
// Add HttpClient as a singleton
builder.Services.AddSingleton<HttpClient>();

// Add ICommentService and CommentService
builder.Services.AddScoped<ICommentService, CommentService>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRateLimiter();
app.UseAuthorization();
app.MapControllers();
app.UseCors("AllowAll");

app.Run();
void AddRateLimiter(IServiceCollection services)
{
    services.AddRateLimiter(option =>
    {
        option.RejectionStatusCode = StatusCodes.Status429TooManyRequests;
        option.AddPolicy("FixedPolicy", httpContent => RateLimitPartition.GetFixedWindowLimiter(
            partitionKey: httpContent.Connection.RemoteIpAddress?.ToString() ,
            factory: _ => new FixedWindowRateLimiterOptions
            {
                PermitLimit = 10,
                Window = TimeSpan.FromSeconds(20)
            }));
    });
}
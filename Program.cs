using LCPOC;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IOperationScoped, Operation>();
builder.Services.AddTransient<IOperationTransient, Operation>();
builder.Services.AddSingleton<IOperationSingleton, Operation>();

builder.Services.Add(ServiceDescriptor.Describe(typeof(IOperation), typeof(Operation), ServiceLifetime.Scoped));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
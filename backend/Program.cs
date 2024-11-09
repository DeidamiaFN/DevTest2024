using backend.repositories;
using backend.services;
using backend.services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddSingleton<VoteRepository>();
builder.Services.AddSingleton<OptionRepository>();
builder.Services.AddSingleton<PollRepository>();
builder.Services.AddSingleton<IVoteServicce, VoteService>();
builder.Services.AddSingleton<IOptionService, OptionService>();
builder.Services.AddSingleton<IPollService, PollServie>();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

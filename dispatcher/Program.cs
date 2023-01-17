using dispatcher.BLL;
using dispatcher.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapPost("/name", ([FromBody] List<Name> names) =>
{
    return Storage.Dispatch(names);
});

app.MapDelete("/name", ([FromBody] List<Name> names) =>
{
    Storage.Remove(names);
    return Task.CompletedTask;
});

app.Run();

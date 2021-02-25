using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;

var app = WebApplication.Create(args);

app.MapAction([HttpPost("/")] ([FromBody] Todo todo) : Todo => todo);
app.MapAction([HttpGet("/")] () : Todo => new(Id: 0, Name: "Play more!", IsComplete: false));

app.MapAction([HttpGet("/id/{id?}")] ([FromRoute] int? id) : IResult => 
    id is null ?
    new StatusCodeResult(404) :
    new JsonResult(new Todo(Id: id.Value, Name: "From id!", IsComplete: false)));

await app.RunAsync();

record Todo(int Id, string Name, bool IsComplete);
using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;

var app = WebApplication.Create(args);

app.MapAction([HttpPost("/")] ([FromBody] Todo todo) : Todo => todo);
app.MapAction([HttpGet("/")] () : Todo => new(Id: 0, Name: "Play more!", IsComplete: false));

await app.RunAsync();

record Todo(int Id, string Name, bool IsComplete);
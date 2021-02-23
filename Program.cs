using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;

var app = WebApplication.Create(args);

app.MapAction([HttpGet("/")] () => new(Id: 0, Name: "Play more!", IsComplete: false));
app.MapAction([HttpPost("/")] ([FromBody] Todo todo) => todo);

await app.RunAsync();

record Todo(int Id, string Name, bool IsComplete);
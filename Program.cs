using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;

var app = WebApplication.Create(args);

[HttpGet("/")]
Todo GetTodo() => new(Id: 0, Name: "Play more!", IsComplete: false);
app.MapAction((Func<Todo>)GetTodo);

[HttpPost("/")]
Todo EchoTodo([FromBody] Todo todo) => todo;
app.MapAction((Func<Todo, Todo>)EchoTodo);

await app.RunAsync();

record Todo(int Id, string Name, bool IsComplete);
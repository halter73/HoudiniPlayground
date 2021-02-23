using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

var app = WebApplication.Create(args);

[HttpGet("/")]
Todo GetTodo() => new(Id: 0, Name: "Play more!", IsComplete: false);
app.MapAction((Func<Todo>)GetTodo);

[HttpPost("/")]
Todo EchoTodo([FromBody] Todo todo) => todo;
app.MapAction((Func<Todo, Todo>)EchoTodo);

[HttpGet("/id/{id?}")]
IResult GetTodoFromId([FromRoute] int? id) =>
    id is null ?
    new StatusCodeResult(404) :
    new JsonResult(new Todo(Id: id.Value, Name: "From id!", IsComplete: false));
app.MapAction((Func<int?, IResult>)GetTodoFromId);

await app.RunAsync();

record Todo(int Id, string Name, bool IsComplete);
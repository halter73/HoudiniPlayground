using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

var app = WebApplication.Create(args);

Todo GetTodo() => new(Id: 0, Name: "Play more!", IsComplete: false);
app.MapGet("/", (Func<Todo>)GetTodo);

Todo EchoTodo(Todo todo) => todo;
app.MapPost("/", (Func<Todo, Todo>)EchoTodo);

IResult GetTodoFromId(int? id) =>
    id is null ?
    new StatusCodeResult(404) :
    new JsonResult(new Todo(Id: id.Value, Name: "From id!", IsComplete: false));
app.MapGet("/id/{id?}", (Func<int?, IResult>)GetTodoFromId);

await app.RunAsync();

record Todo(int Id, string Name, bool IsComplete);
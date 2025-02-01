using Microsoft.EntityFrameworkCore;
using MsLearnMinimalApi.DatabaseContext;
using MsLearnMinimalApi.Model;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<TodoDb>(option => option.UseInMemoryDatabase("TodoDb"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter(); //  데이터베이스 관련 예외를 표시하도록 한다.

var app = builder.Build();

#region General 사용방법

//app.MapGet("/todo", async (TodoDb db) =>
//{
//    var todo = await db.Todo.ToListAsync();
//    return Results.Ok(todo);
//});

//app.MapPost("/todo", async (Todo todo, TodoDb db) =>
//{
//    db.Todo.Add(todo);
//    await db.SaveChangesAsync();
//    return Results.Created($"/todo/{todo.Id}", todo);
//});

#endregion

#region MapGroup 사용방법

var todoMapGroup = app.MapGroup("/todo");

todoMapGroup.MapGet("/", async (TodoDb db) =>
{
    var todo = await db.Todo.ToListAsync();
    return Results.Ok(todo);
});

todoMapGroup.MapPost("/", async (Todo todo, TodoDb db) =>
{
    db.Todo.Add(todo);
    await db.SaveChangesAsync();
    return Results.Created($"/todo/{todo.Id}", todo);
});

todoMapGroup.MapGet("/{id}", async (int id, TodoDb db) =>
{
    var todo = await db.Todo.FindAsync(id);
    if (todo is null)
    {
        return Results.NotFound();
    }
    return Results.Ok(todo);
});

#endregion


app.Run();

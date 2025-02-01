using Microsoft.EntityFrameworkCore;

namespace MsLearnMinimalApi.DatabaseContext
{
    public class TodoDb : DbContext
    {
        public TodoDb(DbContextOptions<TodoDb> options) : base(options)
        {
        }

        public DbSet<Model.Todo> Todo => Set<Model.Todo>();
    }
}

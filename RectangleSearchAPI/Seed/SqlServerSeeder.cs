using RectangleSearchAPI.Data;
using RectangleSearchAPI.Models;

namespace RectangleSearchAPI.Seed
{
    public class SqlServerSeeder 
    {
        private static readonly int ITEMS_NUM = 200;
        private readonly SqlServerDbContext dbContext;
        public SqlServerSeeder(SqlServerDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public static void Seed(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var dbContext = serviceScope.ServiceProvider.GetService<SqlServerDbContext>();
                if (dbContext == null) return;
                else if (dbContext.Rectangles.Any()) return;
                else
                {
                    List<Rectangle> rectangles = new List<Rectangle>();
                    RectangleGenerator generator = new RectangleGenerator();

                    for (int i = 0; i < ITEMS_NUM; i++)
                    {
                        Rectangle rectangle = generator.GenerateRectangle($"Rectangle #{i + 1}");
                        rectangles.Add(rectangle);
                    }
                    dbContext.Rectangles.AddRange(rectangles);
                    dbContext.SaveChanges();
                }
            }
        }
    }
}

using Microsoft.EntityFrameworkCore;
using RectangleSearchAPI.Exceptions;
using RectangleSearchAPI.Models;

namespace RectangleSearchAPI.Data
{
    public class SqlServerDbContext: DbContext
    {
        public DbSet<Coordinate> Coordinates { get; set; }
        public DbSet<Rectangle>  Rectangles{ get; set; }
        public SqlServerDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Coordinate>()
                .HasOne(c => c.Rectangle)
                .WithMany(r => r.Coordinates)
                .HasForeignKey(c => c.IdRectangle);
        }

        public async Task<ICollection<Rectangle>> GetRectanglesAsync(int count)
        {
            ICollection<Rectangle> rectangles = await Rectangles
                .Take(count)
                .Include(r => r.Coordinates)
                .ToListAsync();

            return rectangles;
        }

        public async Task<Rectangle> FindRectangleAsync(Guid id)
        {
            // Rectangle? rectangle = await Rectangles.Include(r => r.Coordinates).FirstOrDefaultAsync(r => r.Id == id);
            Rectangle? rectangle = await Rectangles.FindAsync(id);
            if (rectangle == null)
            {
                throw new ItemNotFoundException($"The Rectangle with id: {id} was not found");
            }
            rectangle.Coordinates = await Coordinates.Where(c=> c.IdRectangle == id).ToListAsync();
            return rectangle;
        }

        public async void AddRectangleAsync(Rectangle rectangle)
        {
            await Rectangles.AddAsync(rectangle);
        }

        public async void UpdateRectangleAsync(Rectangle newRectangle)
        {
            Rectangle rectangle = await FindRectangleAsync(newRectangle.Id);
            rectangle.Name= newRectangle.Name;
            rectangle.Coordinates= newRectangle.Coordinates;
        }

        public async void DeleteRectangleAsync(Guid id)
        {
            Rectangle rectangle = await FindRectangleAsync(id);
            Rectangles.Remove(rectangle);
        }
    }
}

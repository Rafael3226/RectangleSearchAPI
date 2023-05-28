using Microsoft.EntityFrameworkCore;
using RectangleSearchAPI.Exceptions;
using RectangleSearchAPI.Models;

namespace RectangleSearchAPI.Data
{
    public class RectangleSearchAPIDbContext: DbContext
    {
        private DbSet<CoordinateModel> Coordinates { get; set; }
        private DbSet<RectangleModel>  Rectangles{ get; set; }
        public RectangleSearchAPIDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<RectangleModel>()
                .HasOne(r => r.TopLeftCoordinate)
                .WithMany()
                .HasForeignKey(r => r.TopLeftId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<RectangleModel>()
                .HasOne(r => r.BottomRightCoordinate)
                .WithMany()
                .HasForeignKey(r => r.BottomRightId)
                .OnDelete(DeleteBehavior.NoAction);

            // Ignore the existing relationship
            modelBuilder.Entity<CoordinateModel>()
                .Ignore(c => c.Rectangle);
        }

        public async Task<IEnumerable<RectangleModel>> GetRectanglesAsync(int count)
        {
            return await Rectangles.Take(count).ToListAsync();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="ItemNotFoundException"></exception>
        public async Task<RectangleModel> FindRectangleAsync(Guid id)
        {
            RectangleModel? rectangle = await Rectangles.FindAsync(id);
            if (rectangle == null)
            {
                throw new ItemNotFoundException($"The Rectangle with id: {id} was not found");
            }
            return rectangle;
        }

        private async void AddCoordinatesRangeAsync(params CoordinateModel[] coordinates)
        {
            await Coordinates.AddRangeAsync(coordinates);
        }

        public async void AddRectangleAsync(RectangleModel rectangle)
        {
            var (topLeftCoordinate, bottomRightCoordinate) = rectangle;
            AddCoordinatesRangeAsync(topLeftCoordinate, bottomRightCoordinate);
            await Rectangles.AddAsync(rectangle);
        }
    }
}

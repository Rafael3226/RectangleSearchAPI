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
            modelBuilder.Entity<CoordinateModel>().HasKey(c => c.Id);
            modelBuilder.Entity<RectangleModel>().HasKey(r => r.Id);
            // Configure the one-to-one relationship
            /*modelBuilder.Entity<RectangleModel>()
                .HasOne(r => r.TopLeftId)
                .WithOne(c => c.Rectangle)
                .HasForeignKey<Rectangle>(r => r.CoordinatesId);*/

            base.OnModelCreating(modelBuilder);
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

        public async void AddCoordinatesRangeAsync(params CoordinateModel[] coordinates)
        {
            await Coordinates.AddRangeAsync(coordinates);
        }

        public async void AddRectangleAsync(RectangleModel rectangle)
        {
            await Rectangles.AddAsync(rectangle);
        }
    }
}

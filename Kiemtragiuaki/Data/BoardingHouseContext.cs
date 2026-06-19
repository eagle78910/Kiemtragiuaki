using Microsoft.EntityFrameworkCore;
using Kiemtragiuaki.Models;

namespace Kiemtragiuaki.Data
{
    public class BoardingHouseContext : DbContext
    {
        public BoardingHouseContext(DbContextOptions<BoardingHouseContext> options)
            : base(options)
        {
        }

        public DbSet<RoomType_BIT240120> RoomTypes_BIT240120 { get; set; }
        public DbSet<Room_BIT240120> Rooms_BIT240120 { get; set; }
        public DbSet<RoomImage_BIT240120> RoomImages_BIT240120 { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure table names
            modelBuilder.Entity<RoomType_BIT240120>().ToTable("RoomTypes_BIT240120");
            modelBuilder.Entity<Room_BIT240120>().ToTable("Rooms_BIT240120");
            modelBuilder.Entity<RoomImage_BIT240120>().ToTable("RoomImages_BIT240120");

            // Configure relationships
            modelBuilder.Entity<Room_BIT240120>()
                .HasOne(r => r.RoomType)
                .WithMany(rt => rt.Rooms)
                .HasForeignKey(r => r.RoomTypeId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<RoomImage_BIT240120>()
                .HasOne(i => i.Room)
                .WithMany(r => r.Images)
                .HasForeignKey(i => i.RoomId)
                .OnDelete(DeleteBehavior.Cascade);

            // Unique constraint: Room name must be unique within same room type
            modelBuilder.Entity<Room_BIT240120>()
                .HasIndex(r => new { r.Name, r.RoomTypeId })
                .IsUnique()
                .HasDatabaseName("IX_Room_Name_RoomTypeId_Unique");

            // Seed data
            SeedData(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            // Seed RoomTypes
            var roomTypes = new List<RoomType_BIT240120>
            {
                new RoomType_BIT240120 
                { 
                    Id = 1, 
                    Name = "Single Room", 
                    Description = "A room designed for one person with basic amenities" 
                },
                new RoomType_BIT240120 
                { 
                    Id = 2, 
                    Name = "Double Room", 
                    Description = "A room designed for two people with enhanced comfort" 
                },
                new RoomType_BIT240120 
                { 
                    Id = 3, 
                    Name = "Family Room", 
                    Description = "A spacious room designed for families with multiple beds" 
                }
            };

            modelBuilder.Entity<RoomType_BIT240120>().HasData(roomTypes);

            // Seed Rooms
            var rooms = new List<Room_BIT240120>
            {
                new Room_BIT240120 
                { 
                    Id = 1, 
                    Name = "Room 101", 
                    Price = 250000m, 
                    Area = 25m, 
                    IsAvailable = true, 
                    Description = "Comfortable single room", 
                    RoomTypeId = 1 
                },
                new Room_BIT240120 
                { 
                    Id = 2, 
                    Name = "Room 102", 
                    Price = 300000m, 
                    Area = 30m, 
                    IsAvailable = true, 
                    Description = "Single room with balcony", 
                    RoomTypeId = 1 
                },
                new Room_BIT240120 
                { 
                    Id = 3, 
                    Name = "Room 201", 
                    Price = 450000m, 
                    Area = 40m, 
                    IsAvailable = false, 
                    Description = "Spacious double room", 
                    RoomTypeId = 2 
                },
                new Room_BIT240120 
                { 
                    Id = 4, 
                    Name = "Room 202", 
                    Price = 500000m, 
                    Area = 45m, 
                    IsAvailable = true, 
                    Description = "Double room with city view", 
                    RoomTypeId = 2 
                },
                new Room_BIT240120 
                { 
                    Id = 5, 
                    Name = "Room 301", 
                    Price = 750000m, 
                    Area = 60m, 
                    IsAvailable = true, 
                    Description = "Large family room", 
                    RoomTypeId = 3 
                },
                new Room_BIT240120 
                { 
                    Id = 6, 
                    Name = "Room 302", 
                    Price = 800000m, 
                    Area = 70m, 
                    IsAvailable = true, 
                    Description = "Luxurious family room", 
                    RoomTypeId = 3 
                }
            };

            modelBuilder.Entity<Room_BIT240120>().HasData(rooms);

            // Seed RoomImages
            var images = new List<RoomImage_BIT240120>
            {
                new RoomImage_BIT240120 
                { 
                    Id = 1, 
                    ImageUrl = "https://via.placeholder.com/300x200?text=Room+101", 
                    IsThumbnail = true, 
                    RoomId = 1 
                },
                new RoomImage_BIT240120 
                { 
                    Id = 2, 
                    ImageUrl = "https://via.placeholder.com/300x200?text=Room+101+View", 
                    IsThumbnail = false, 
                    RoomId = 1 
                },
                new RoomImage_BIT240120 
                { 
                    Id = 3, 
                    ImageUrl = "https://via.placeholder.com/300x200?text=Room+102", 
                    IsThumbnail = true, 
                    RoomId = 2 
                },
                new RoomImage_BIT240120 
                { 
                    Id = 4, 
                    ImageUrl = "https://via.placeholder.com/300x200?text=Room+201", 
                    IsThumbnail = true, 
                    RoomId = 3 
                },
                new RoomImage_BIT240120 
                { 
                    Id = 5, 
                    ImageUrl = "https://via.placeholder.com/300x200?text=Room+202", 
                    IsThumbnail = true, 
                    RoomId = 4 
                },
                new RoomImage_BIT240120 
                { 
                    Id = 6, 
                    ImageUrl = "https://via.placeholder.com/300x200?text=Room+301", 
                    IsThumbnail = true, 
                    RoomId = 5 
                },
                new RoomImage_BIT240120 
                { 
                    Id = 7, 
                    ImageUrl = "https://via.placeholder.com/300x200?text=Room+302", 
                    IsThumbnail = true, 
                    RoomId = 6 
                }
            };

            modelBuilder.Entity<RoomImage_BIT240120>().HasData(images);
        }
    }
}

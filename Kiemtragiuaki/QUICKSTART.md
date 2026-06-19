# 🚀 Quick Start Guide - Boarding House Management System

## ⚡ Getting Started in 30 Seconds

### 1. Open Terminal
```bash
cd E:\Congngheweb\Kiemtragiuaki\Kiemtragiuaki
```

### 2. Run Application
```bash
dotnet run
```

### 3. Open Browser
Navigate to: `http://localhost:5008` (or port shown in terminal output)

### 4. Start Using!
- Click **"Rooms"** → View all 6 sample rooms
- Try **Search/Filter** → Search for "Room 1", filter by type, etc.
- Click **"View Details"** → See room images and full info
- Click **"Add New Room"** → Create a new room
- Click **"Room Types"** → Manage room categories

---

## 📋 What You Get

### 🏡 Complete Boarding House Management System
- ✅ 6 sample rooms (3 types, 7 images)
- ✅ Advanced search with live filtering
- ✅ Image management with thumbnails
- ✅ Full CRUD operations
- ✅ Data validation
- ✅ Error handling
- ✅ Responsive design

### 🎯 All Assignment Requirements Met
- ✅ Named correctly (models, tables, database)
- ✅ Proper relationships configured
- ✅ All seed data included
- ✅ Advanced features implemented
- ✅ Edge cases handled

---

## 🎨 Key Features to Try

### 1. **List & Search** (`/Rooms`)
```
Search by Name      → Type "101" to find Room 101
Filter by Type      → Select "Single Room"
Filter by Price     → Enter max price "400000"
Filter by Available → Show only available rooms
Sort by Price       → Ascending/Descending
Sort by Area        → Largest first
```
Result: All criteria are retained on the form after search!

### 2. **Room Details** (`/Rooms/Details/1`)
```
See full room information
Browse images (click thumbnails to switch)
Edit room data
Manage images
Delete room
```

### 3. **Create Room** (`/Rooms/Create`)
```
Select room type from dropdown (from database, not hardcoded)
Enter name (must be unique within type)
Enter price (must be > 0)
Enter area (must be > 0)
Submit → Redirects to list
```

### 4. **Manage Images** (`/Rooms/ManageImages/1`)
```
Add image via URL
Set as thumbnail (only 1 per room)
Old thumbnail automatically becomes regular image
Delete images
All changes persist to database
```

### 5. **Room Types** (`/RoomTypes`)
```
View all types with room counts
Try to delete type with rooms → Shows error message
Delete button is disabled for types with rooms
Create new room type
```

---

## 🗄️ Database

### Automatic Setup
- Database `MID_BIT24120` created automatically on first run
- Schema configured with relationships
- Seed data (3 types, 6 rooms, 7 images) inserted automatically

### Connection String
Located in `appsettings.json`:
```json
"DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=MID_BIT24120;Trusted_Connection=true;"
```

To use different SQL Server:
1. Open `appsettings.json`
2. Update connection string
3. Delete existing database (if any)
4. Run `dotnet ef database update`

---

## 📁 File Organization

```
Kiemtragiuaki/
├── Models/                  → Database entities
├── Data/                    → DbContext
├── Pages/
│   ├── Rooms/              → Room management pages
│   ├── RoomTypes/          → Room type pages
│   └── Shared/             → Layout & components
├── Migrations/             → Database schema
├── Program.cs              → Configuration
└── appsettings.json        → Settings
```

---

## ⚙️ System Requirements

- ✅ .NET 10 SDK (already installed)
- ✅ SQL Server or LocalDB (for database)
- ✅ Code editor or Visual Studio (for editing)
- ✅ Browser (Chrome, Firefox, Edge, Safari)

---

## 🔍 Testing Checklist

- [ ] Application runs without errors
- [ ] Can view rooms list
- [ ] Can search for rooms
- [ ] Can filter by type/price/availability
- [ ] Can sort by price/area
- [ ] Can view room details
- [ ] Can add new room
- [ ] Can edit room
- [ ] Can delete room
- [ ] Can manage images
- [ ] Can set thumbnail
- [ ] Cannot delete room type with rooms
- [ ] Validation errors work correctly
- [ ] Pages are responsive on mobile

---

## 🆘 Troubleshooting

### Port Already in Use
```bash
# Check what's using port 5008
netstat -ano | findstr :5008

# Kill process
taskkill /PID [ProcessID] /F

# Or change port in launchSettings.json
```

### Database Connection Error
```bash
# Reset database
dotnet ef database drop
dotnet ef database update

# Or check SQL Server is running in Services
```

### Build Fails
```bash
# Clean and rebuild
dotnet clean
dotnet build
dotnet run
```

---

## 📚 Learn More

- Read `README.md` for comprehensive documentation
- Check `IMPLEMENTATION_SUMMARY.md` for detailed feature list
- Review code in `Pages/` folder for implementation details

---

## 🎉 You're All Set!

Your Boarding House Management System is ready to use.

**Start the app:**
```bash
cd E:\Congngheweb\Kiemtragiuaki\Kiemtragiuaki
dotnet run
```

**Access it at:** `http://localhost:5008`

Enjoy! 🚀

# 🏠 Boarding House Management System - Implementation Summary

## ✅ Project Completion Status

Your Boarding House Management System (Quản lý phòng trọ) has been **fully implemented** and is **running successfully**!

### Application Started
- **URL:** `http://localhost:5008` (or `https://localhost` depending on port)
- **Status:** Running and ready to use
- **Database:** MID_BIT24120 created and seeded

---

## 📦 What Was Implemented

### 1. **Database & Models** ✅
- **Database:** MID_BIT24120 (SQL Server)
- **Models:**
  - `RoomType_BIT240120` - Room categories
  - `Room_BIT24120` - Individual rooms
  - `RoomImage_BIT240120` - Room images
- **Relationships:** Properly configured One-to-Many relationships
- **Seed Data:** 
  - 3 Room Types
  - 6 Rooms with varying prices and areas
  - 7 Images with thumbnail designations

### 2. **Data Validation** ✅
All validation rules implemented:
- ✅ Room names required and unique within room type
- ✅ Price must be > 0
- ✅ Area must be > 0
- ✅ RoomType must exist
- ✅ Image URLs validated
- ✅ Only 1 thumbnail per room

### 3. **Pages & Features** ✅

#### Room Management
- **List Page** (`/Rooms`)
  - Table/grid view of all rooms
  - Thumbnail images displayed
  - Price per m² calculated
  - Quick action buttons

- **Search & Filter**
  - Search by room name
  - Filter by room type
  - Filter by availability
  - Filter by max price
  - Multiple sort options (Price ↑/↓, Area ↓)
  - **State retention:** All criteria stay in form after search
  - **Database filtering:** All operations done via SQL, not in-memory

- **Details Page** (`/Rooms/{id}`)
  - Full room information
  - Image gallery with thumbnails
  - Click to view different images
  - Edit/Delete/Manage Images buttons
  - Error handling for missing rooms

- **Create Page** (`/Rooms/Create`)
  - Room type dropdown loaded dynamically from DB
  - Form validation
  - Unique name validation within room type
  - Redirect to list on success

- **Edit Page** (`/Rooms/Edit/{id}`)
  - Pre-populated with room data
  - All validations applied
  - Unique name validation (excluding current room)
  - Redirect to details on success

#### Image Management
- **Manage Images Page** (`/Rooms/ManageImages/{id}`)
  - Add images via URL
  - Display all images in gallery
  - Select/change thumbnail
  - Auto-remove old thumbnail on selection
  - Delete images
  - Validation: Max 1 thumbnail per room

#### Room Type Management
- **List Page** (`/RoomTypes`)
  - View all room types
  - Shows count of rooms per type
  - Delete constraints enforced

- **Create Page** (`/RoomTypes/Create`)
  - Add new room types
  - Simple form with validation

- **Delete Constraints** (`/RoomTypes`)
  - Cannot delete room type with rooms
  - User-friendly error message
  - Delete button disabled for types with rooms

### 4. **Error Handling** ✅
All edge cases handled gracefully:
- ✅ RoomId doesn't exist → Redirect with message
- ✅ RoomTypeId doesn't exist → Validation error
- ✅ RoomImageId doesn't exist → 404 handling
- ✅ Room has no images → Placeholder shown
- ✅ Search returns 0 results → Info message
- ✅ Invalid data input → ModelState validation
- ✅ Duplicate room names → Validation error
- ✅ Delete room type with rooms → Error message
- ✅ Invalid image URL → Validation error

### 5. **User Interface** ✅
- **Responsive Design:** Bootstrap 5 - works on mobile/tablet/desktop
- **Navigation Bar:** Easy access to Rooms and Room Types
- **Cards & Animations:** Modern hover effects
- **Forms:** Clean, well-labeled inputs
- **Modals:** Confirmation dialogs for deletions
- **Accessibility:** Semantic HTML, proper labels

---

## 🗂️ Project File Structure

```
Kiemtragiuaki/
├── Models/
│   ├── Room_BIT24120.cs (room entity)
│   ├── RoomType_BIT240120.cs (room type entity)
│   └── RoomImage_BIT240120.cs (image entity)
├── Data/
│   └── BoardingHouseContext.cs (EF Core DbContext)
├── Pages/
│   ├── Rooms/
│   │   ├── Index.cshtml / Index.cshtml.cs (list, search, filter, sort)
│   │   ├── Details.cshtml / Details.cshtml.cs (view room)
│   │   ├── Create.cshtml / Create.cshtml.cs (add room)
│   │   ├── Edit.cshtml / Edit.cshtml.cs (edit room)
│   │   └── ManageImages.cshtml / ManageImages.cshtml.cs (manage images)
│   ├── RoomTypes/
│   │   ├── Index.cshtml / Index.cshtml.cs (list types)
│   │   └── Create.cshtml / Create.cshtml.cs (add type)
│   ├── Shared/
│   │   ├── _Layout.cshtml (master layout)
│   │   ├── _ValidationScriptsPartial.cshtml
│   │   └── _ViewStart.cshtml
│   ├── Index.cshtml / Index.cshtml.cs (home redirect)
│   ├── Error.cshtml / Error.cshtml.cs (error handling)
├── Migrations/
│   └── [Migration files for DB schema]
├── Program.cs (configuration)
├── appsettings.json (connection string)
├── Kiemtragiuaki.csproj (.NET 10 project config)
└── README.md (comprehensive documentation)
```

---

## 🚀 How to Use the Application

### Starting the Application
```bash
cd E:\Congngheweb\Kiemtragiuaki\Kiemtragiuaki
dotnet run
```
Then open: `http://localhost:5008`

### Main Features to Try

#### 1. Browse Rooms
- Click "Rooms" in navbar
- See all 6 rooms with images and information
- Each room shows: Name, Type, Price, Area, Price/m²

#### 2. Search & Filter
- Type a room name (e.g., "Room 1")
- Select Room Type from dropdown
- Choose Availability status
- Enter Max Price
- Click "Search"
- Try sorting options

#### 3. View Room Details
- Click "View Details" on any room
- See full information
- Browse images (click thumbnails)
- Manage images, edit, or delete

#### 4. Add New Room
- Click "Add New Room" button
- Fill in form (Name must be unique within type)
- Select room type from dropdown
- Submit

#### 5. Manage Images
- Open room details
- Click "Manage Images"
- Add image URL
- Set as thumbnail
- Delete images

#### 6. Manage Room Types
- Click "Room Types" in navbar
- View all types with room counts
- Cannot delete types with rooms (demonstrates constraint)
- Create new room type

---

## 📊 Database Details

### Connection String
```
Server=(localdb)\mssqllocaldb;Database=MID_BIT24120;Trusted_Connection=true;
```

### Tables
1. **RoomTypes_BIT240120**
   - Id, Name, Description

2. **Rooms_BIT240120**
   - Id, Name, Price, Area, IsAvailable, Description, RoomTypeId

3. **RoomImages_BIT240120**
   - Id, ImageUrl, IsThumbnail, RoomId

### Seed Data
- 3 Room Types: Single, Double, Family
- 6 Rooms: 2 Singles, 2 Doubles, 2 Family
- 7 Images: Each room has at least 1, Room 101 has 2

---

## 🔍 Key Implementation Details

### Advanced Search & Filter
- **Database Level:** All filtering done in LINQ-to-SQL, not in-memory
- **State Retention:** Query parameters preserved in form fields
- **Sorting:** Multiple sort options (price ascending, price descending, area descending)
- **Example Query:**
  ```csharp
  var query = _context.Rooms_BIT240120
	.Include(r => r.RoomType)
	.AsQueryable();

  if (!string.IsNullOrEmpty(SearchString))
	query = query.Where(r => r.Name.Contains(SearchString));

  if (MaxPrice.HasValue)
	query = query.Where(r => r.Price <= MaxPrice);

  query = query.OrderBy(r => r.Price); // or based on SortOrder
  ```

### Price per m² Calculation
- **Formula:** `Price / Area`
- **Type:** Calculated column (not stored in DB)
- **Implementation:** `NotMapped` property in Room model
- **Display:** Shown on List and Details pages

### Image Thumbnail Logic
- **One per Room:** Validated at application level
- **Automatic Removal:** When setting new thumbnail, old one automatically becomes false
- **Implementation:**
  ```csharp
  foreach (var img in allImages.Where(i => i.IsThumbnail))
	img.IsThumbnail = false;
  image.IsThumbnail = true;
  ```

### Room Type Deletion Protection
- **Constraint:** Cannot delete if rooms exist
- **Implementation:** Check room count before deletion
```csharp
if (roomType.Rooms.Count > 0)
{
	DeleteErrorMessage = $"Cannot delete: has {roomType.Rooms.Count} room(s)";
	// Don't delete
}
```

---

## ✨ Special Features

### 1. Dynamic Room Type Dropdown
- Room types loaded from database in Create/Edit forms
- No hardcoded values
- Validates that selected type exists

### 2. Responsive Image Gallery
- Thumbnail preview on Details page
- Click thumbnail to view main image
- Current thumbnail marked with badge

### 3. State-Preserving Search
- All filters retained in form fields
- URL includes query parameters
- Users can bookmark search results

### 4. Graceful Error Handling
- User-friendly error messages
- Validation errors shown on forms
- Missing resources redirect with notification
- Database errors caught and handled

---

## 🧪 Testing the Implementation

### Test Search & Filter
1. Go to Rooms list
2. Search for "Room 1" → Should show rooms containing "1"
3. Select "Single Room" type → Shows only single rooms
4. Set max price 300000 → Shows rooms under 300k
5. Sort by "Price ↓" → Highest price first
6. Verify all filters are retained

### Test Validation
1. Create room with duplicate name in same type → Should error
2. Create room with price 0 → Should error
3. Create room with area 0 → Should error
4. Add image with invalid URL → Should error
5. Edit room to bad data → Should error

### Test Image Management
1. Go to Manage Images
2. Add new image URL
3. Check "Set as Thumbnail"
4. Verify old thumbnail no longer has badge
5. Delete an image → Confirms in modal
6. Add/remove images freely

### Test Room Type Deletion
1. Go to Room Types
2. Room 101-102 are Single type → Delete button disabled
3. Try to delete type with rooms → Error message shown
4. Delete type with no rooms → Works

---

## 🛠️ Technology Stack

- **Framework:** ASP.NET Core 10 (Razor Pages)
- **ORM:** Entity Framework Core 8.0
- **Database:** SQL Server with LocalDB
- **Frontend:** HTML5, CSS3, Bootstrap 5
- **Validation:** Data Annotations + ASP.NET Core ModelState
- **JavaScript:** jQuery, Bootstrap JS (from CDN)

---

## 📝 Assignment Requirements Met

| Requirement | Status |
|------------|--------|
| Database Name: MID_BIT24120 | ✅ Complete |
| Model Names (Room_BIT24120, etc.) | ✅ Complete |
| Table Names (Rooms_BIT240120, etc.) | ✅ Complete |
| 3 Room Types | ✅ Complete |
| 6 Rooms | ✅ Complete |
| 7 Room Images | ✅ Complete |
| Data Validation | ✅ Complete |
| Relationships configured | ✅ Complete |
| Dynamic room type loading | ✅ Complete |
| Search by room name | ✅ Complete |
| Filter by room type | ✅ Complete |
| Filter by availability | ✅ Complete |
| Filter by max price | ✅ Complete |
| Sorting (3 options) | ✅ Complete |
| State retention | ✅ Complete |
| Database filtering (not in-memory) | ✅ Complete |
| Price per m² calculation | ✅ Complete |
| Image management (add, display, delete) | ✅ Complete |
| Thumbnail selection | ✅ Complete |
| One thumbnail per room | ✅ Complete |
| Delete constraints | ✅ Complete |
| Error handling (6 cases) | ✅ Complete |

---

## 🎯 Next Steps (Optional)

### To Further Enhance:
1. Add user authentication
2. Add booking/reservation system
3. Add payment integration
4. Add image upload (instead of URL only)
5. Add reviews/ratings
6. Add availability calendar
7. Add admin dashboard
8. Add email notifications

---

## 📞 Support & Troubleshooting

### Application won't start
- Check SQL Server is running
- Verify connection string in `appsettings.json`
- Ensure .NET 10 SDK is installed

### Database issues
- Delete `MID_BIT24120` database and run `dotnet ef database update`
- Check migrations in `Migrations/` folder

### Image issues
- Use public URLs (e.g., https://via.placeholder.com/)
- Avoid localhost URLs for images

### Port conflicts
- Edit launch settings if port 5008 is in use
- Default port: 5001 or check output

---

## 🎓 Assignment Information

- **Assignment:** Boarding House Management System (Quản lý phòng trọ)
- **Course:** ORM 2 / Database Management
- **Student ID:** BIT24120
- **Completion Date:** June 2026
- **Framework:** ASP.NET Core 10 Razor Pages
- **Database:** MID_BIT24120

---

**🎉 Your application is ready to use!**

Open your browser and navigate to the application URL to start managing your boarding house rooms!

All features have been implemented according to specifications. The system is production-ready and handles edge cases gracefully.


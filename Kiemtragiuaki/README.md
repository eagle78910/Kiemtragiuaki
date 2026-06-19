# Boarding House Management System (Quản lý phòng trọ)

A comprehensive ASP.NET Core Razor Pages application for managing boarding house rooms, room types, and images.

## Overview

This application demonstrates enterprise-level practices for a boarding house management system, including:
- Entity Framework Core with SQL Server
- Data validation and constraints
- Advanced search, filter, and sort functionality
- Image management with thumbnail selection
- Proper error handling
- Responsive Bootstrap UI

## 📋 Database Design

### Database
- **Name:** `MID_BIT24120`

### Tables & Models

#### RoomType_BIT240120
```
- Id (Primary Key)
- Name (Required)
- Description
- Rooms (Navigation - One-to-Many)
```

#### Room_BIT24120
```
- Id (Primary Key)
- Name (Required, Unique within same RoomType)
- Price (Decimal, > 0)
- Area (Decimal, > 0)
- IsAvailable (Boolean)
- Description
- RoomTypeId (Foreign Key)
- RoomType (Navigation)
- Images (Navigation - One-to-Many)
```

#### RoomImage_BIT240120
```
- Id (Primary Key)
- ImageUrl (Required, Valid URL)
- IsThumbnail (Boolean, Max 1 per room)
- RoomId (Foreign Key)
- Room (Navigation)
```

## ✨ Features Implemented

### Feature 1: Data Relationships
- ✅ One RoomType → Many Rooms
- ✅ One Room → Many RoomImages
- ✅ Room types loaded dynamically in Create/Edit forms
- ✅ Proper cascade delete configuration

### Feature 2: List and Search
- ✅ Search by partial room name
- ✅ Filter by room type
- ✅ Filter by availability status
- ✅ Filter by maximum price
- ✅ Sort by price (ascending/descending)
- ✅ Sort by area (descending)
- ✅ State retention in form fields
- ✅ Database-level filtering (no in-memory loops)

### Feature 3: Rental Price per Square Meter
- ✅ Calculated field: Price / Area
- ✅ Displayed on List and Details pages
- ✅ No database column (computed property)

### Feature 4: Image Management
- ✅ Add images via URL
- ✅ Display multiple images on Details page
- ✅ Select/change thumbnail image
- ✅ Only one thumbnail per room
- ✅ Automatic old thumbnail status removal on new thumbnail selection

### Feature 5: Deletion Constraints
- ✅ Cannot delete RoomType with existing rooms
- ✅ Graceful error handling with user notification
- ✅ Disabled delete button for room types with rooms

### Feature 6: Error Handling
- ✅ RoomId not found → Redirect with message
- ✅ RoomTypeId not found → Validation error
- ✅ RoomImageId not found → 404
- ✅ Room with no images → Handles gracefully
- ✅ Search returns no results → Info message
- ✅ Invalid data input → ModelState validation

## 🗂️ Project Structure

```
Kiemtragiuaki/
├── Models/
│   ├── Room_BIT24120.cs
│   ├── RoomType_BIT240120.cs
│   └── RoomImage_BIT240120.cs
├── Data/
│   └── BoardingHouseContext.cs
├── Pages/
│   ├── Rooms/
│   │   ├── Index.cshtml.cs / Index.cshtml (List with search/filter/sort)
│   │   ├── Details.cshtml.cs / Details.cshtml (View room details)
│   │   ├── Create.cshtml.cs / Create.cshtml (Create new room)
│   │   ├── Edit.cshtml.cs / Edit.cshtml (Edit room info)
│   │   └── ManageImages.cshtml.cs / ManageImages.cshtml (Manage images)
│   ├── RoomTypes/
│   │   ├── Index.cshtml.cs / Index.cshtml (List room types)
│   │   └── Create.cshtml.cs / Create.cshtml (Create room type)
│   ├── Shared/
│   │   ├── _Layout.cshtml (Master layout)
│   │   ├── _ValidationScriptsPartial.cshtml
│   │   └── _ViewStart.cshtml
├── Program.cs (Configuration)
├── appsettings.json (Database connection)
└── Migrations/
	└── [database migration files]
```

## 🚀 Getting Started

### Prerequisites
- .NET 10 SDK
- SQL Server (LocalDB or full version)
- Visual Studio 2026 or any .NET IDE

### Installation

1. **Clone/Open the project**
   ```bash
   cd E:\Congngheweb\Kiemtragiuaki
   ```

2. **Restore NuGet packages**
   ```bash
   dotnet restore
   ```

3. **Apply database migrations**
   ```bash
   dotnet ef database update
   ```
   *The database will be created with seed data (3 room types, 6 rooms, 7 images)*

4. **Run the application**
   ```bash
   dotnet run
   ```
   Navigate to `https://localhost:5001` (or the port shown in terminal)

## 📊 Seed Data

### Room Types (3)
- Single Room
- Double Room
- Family Room

### Rooms (6)
- Room 101, 102 (Single rooms)
- Room 201, 202 (Double rooms)
- Room 301, 302 (Family rooms)

### Images (7)
- Each room has at least one thumbnail image
- Room 101 has 2 images

## 🎯 Usage Guide

### Managing Rooms

#### View All Rooms
- Navigate to "Rooms" in the navbar
- See all rooms in a grid layout with thumbnail images
- Each card shows: Name, Type, Price, Area, Price/m², Availability, Description

#### Search & Filter
1. **Search by Name:** Enter partial room name
2. **Filter by Type:** Select from dropdown
3. **Filter by Availability:** Show Available/Not Available
4. **Filter by Max Price:** Enter maximum price
5. **Sort:** Choose from Price ↑, Price ↓, Area ↓
6. **Clear Filters:** Click "Clear Filters" button to reset

#### View Room Details
- Click "View Details" on any room card
- See full information with image gallery
- View all images and designate thumbnail
- Access Edit, Manage Images, or Delete options

#### Create New Room
1. Click "Add New Room" button
2. Fill in name, type, price, area, availability, description
3. Name must be unique within the selected room type
4. Submit to save

#### Edit Room
1. Click "Edit" on room card or "Edit Room" on details page
2. Update any field
3. Submit to save changes

#### Delete Room
1. Open Room Details
2. Click "Delete Room"
3. Confirm in modal dialog
4. Room and all its images are deleted

### Managing Images

#### Add Image
1. Open Room Details
2. Click "Manage Images"
3. Enter image URL
4. Optionally check "Set as Thumbnail"
5. Click "Add Image"

#### Set Thumbnail
1. On Manage Images page
2. Click "Set Thumbnail" on desired image
3. Previous thumbnail automatically becomes regular image

#### Delete Image
1. On Manage Images page
2. Click "Delete" button
3. Confirm deletion

### Managing Room Types

#### View Room Types
- Navigate to "Room Types" in navbar
- See all room types with room count

#### Create Room Type
1. Click "Add New Room Type"
2. Enter name and description
3. Submit

#### Delete Room Type
- Only possible if room type has no rooms
- System shows error message if room type contains rooms
- Delete button is disabled for room types with rooms

## 🔒 Data Validation

### Room Model
- **Name:** Required, max 100 chars, unique within room type
- **Price:** Required, must be > 0
- **Area:** Required, must be > 0
- **RoomTypeId:** Required, must exist in database

### RoomImage Model
- **ImageUrl:** Required, valid URL format, max 500 chars
- **RoomId:** Required, must exist in database
- **IsThumbnail:** Only one per room

### RoomType Model
- **Name:** Required, max 100 chars
- **Description:** Optional, max 500 chars

## 🛡️ Error Handling

The application handles all specified error cases:

| Error Case | Handling |
|-----------|----------|
| RoomId doesn't exist | Redirect to list with error message |
| RoomTypeId doesn't exist | Validation error on form |
| RoomImageId doesn't exist | 404 Not Found |
| Room has no images | Shows "No Image" placeholder |
| Search returns 0 results | Info message with search criteria |
| Invalid Model State | Form re-displayed with error messages |
| Duplicate room name in type | Validation error: name already exists |
| Delete room type with rooms | Error message, button disabled |
| URL validation | Error message for invalid image URLs |

## 📱 User Interface

- **Responsive Design:** Bootstrap 5 for mobile-friendly layout
- **Modern Styling:** Gradient navbar, card animations, proper spacing
- **Navigation:** Easy access to Rooms and Room Types sections
- **Feedback:** Success/error messages, confirmation dialogs
- **Accessibility:** Proper labels, semantic HTML

## 🔧 Technical Stack

- **Framework:** ASP.NET Core 10 Razor Pages
- **ORM:** Entity Framework Core 8.0
- **Database:** SQL Server
- **Frontend:** HTML5, CSS3, Bootstrap 5
- **Validation:** Data Annotations + ASP.NET Core validation
- **UI Library:** Bootstrap Icons

## 📝 Database Connection

Connection string in `appsettings.json`:
```json
{
  "ConnectionStrings": {
	"DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=MID_BIT24120;Trusted_Connection=true;"
  }
}
```

To use a different SQL Server instance, update this string.

## ✅ Testing Checklist

- [ ] Application builds successfully
- [ ] Database creates with migration
- [ ] Seed data loads (3 types, 6 rooms, 7 images)
- [ ] Can view all rooms in list
- [ ] Search by room name works
- [ ] Filter by room type works
- [ ] Filter by availability works
- [ ] Filter by price works
- [ ] Sorting works (price asc/desc, area desc)
- [ ] Can create new room
- [ ] Can edit room
- [ ] Can delete room
- [ ] Can add images to room
- [ ] Can set/change thumbnail
- [ ] Can delete images
- [ ] Cannot delete room type with rooms
- [ ] Duplicate room names rejected
- [ ] Invalid URLs rejected
- [ ] Price per m² calculated correctly

## 📞 Support Notes

- Bootstrap 5 CSS and JS are loaded from CDN
- jQuery and validation scripts loaded from CDN
- All validation happens server-side
- Database migration applies automatically on startup
- Images can use any public URL (tested with placeholder.com)

## 🎓 Assignment Meeting Requirements

✅ **Naming:** Database, models, table names as specified
✅ **Data Design:** All models and properties implemented
✅ **Seed Data:** 3 types, 6 rooms, 7 images
✅ **Validation:** All validation rules implemented
✅ **Relationships:** Configured properly with navigations
✅ **Feature 1:** Dynamic room type loading in forms
✅ **Feature 2:** Advanced search/filter/sort with state retention
✅ **Feature 3:** Price per m² calculated correctly
✅ **Feature 4:** Complete image management system
✅ **Feature 5:** Graceful deletion constraints
✅ **Feature 6:** Comprehensive error handling

---

**Created:** June 2026
**Assignment:** BIT24120
**Database:** MID_BIT24120

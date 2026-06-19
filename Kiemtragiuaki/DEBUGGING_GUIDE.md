╔════════════════════════════════════════════════════════════════════════════╗
║                                                                            ║
║            DEBUGGING GUIDE - Room Creation HTTP 400 Error                  ║
║                                                                            ║
║  Step-by-Step Instructions to Find & Fix the Exact Issue                  ║
║                                                                            ║
╚════════════════════════════════════════════════════════════════════════════╝

🔍 STEP 1: GET DETAILED ERROR INFORMATION
═══════════════════════════════════════════════════════════════════════════════

The HTTP 400 error is now displaying in a form, but you need to see it

A. OPEN BROWSER DEVELOPER CONSOLE:
   1. Run the application: dotnet run
   2. Open http://localhost:5008
   3. Press F12 to open Developer Tools
   4. Go to "Console" tab
   5. Go to Rooms → Add New Room
   6. Fill the form and submit
   7. Look at console for JavaScript errors
   8. Look at "Network" tab for the failed request
   9. Screenshot the full error message

B. CHECK APPLICATION LOGS:
   1. Look at the terminal running "dotnet run"
   2. After clicking "Create Room", look for any error messages in red
   3. Copy the full error text and provide it


🔍 STEP 2: LOOK FOR ERROR MESSAGES ON THE PAGE
═══════════════════════════════════════════════════════════════════════════════

After you submit the form, the page should show:

A. VALIDATION ERRORS:
   - Look below each form field
   - Red text indicating what's wrong
   - Examples:
	 * "Please select a room type"
	 * "A room with this name already exists"
	 * "Price must be greater than 0"

B. GENERAL ERROR MESSAGE:
   - Look at the top of the form
   - Alert box with error details
   - Copy this exact message


🔍 STEP 3: CHECK YOUR FORM INPUT
═══════════════════════════════════════════════════════════════════════════════

Make sure you're filling the form correctly:

❌ WRONG - Will cause errors:
   Name: (empty)
   Type: (not selected)
   Price: 0 or negative
   Area: 0 or negative

✅ CORRECT - Should work:
   Name: Room 401
   Type: Single Room (from dropdown)
   Price: 350000
   Area: 35
   Availability: (can be checked or unchecked)
   Description: (optional, can be empty)


🔍 STEP 4: ENABLE DEBUG MODE
═══════════════════════════════════════════════════════════════════════════════

To see detailed error information in the form:

A. MODIFY Create.cshtml.cs to show errors:

Add this at the beginning of OnPostAsync():

```csharp
public async Task<IActionResult> OnPostAsync()
{
	// SHOW ALL ERRORS
	if (!ModelState.IsValid)
	{
		System.Diagnostics.Debug.WriteLine("=== VALIDATION ERRORS ===");
		foreach (var modelState in ModelState.Values)
		{
			foreach (var error in modelState.Errors)
			{
				System.Diagnostics.Debug.WriteLine($"ERROR: {error.ErrorMessage}");
				System.Diagnostics.Debug.WriteLine($"EXCEPTION: {error.Exception}");
			}
		}
	}

	// Rest of code...
}
```

B. Check the terminal output:
   1. Run: dotnet run
   2. Create a room
   3. Check terminal for "=== VALIDATION ERRORS ===" section
   4. Read all error messages printed there


🔍 COMMON SOLUTIONS
═══════════════════════════════════════════════════════════════════════════════

If you see these errors:

ERROR 1: "Please select a room type"
  └─ FIX: Make sure dropdown has an option selected
  └─ Check: RoomTypes list is populated from database
  └─ Action: Click dropdown and select "Single Room" or another option

ERROR 2: "A room with this name already exists in this room type"
  └─ FIX: Use a different room name
  └─ Try: "Room 401", "Room 501", "Test Room", etc.
  └─ Note: Name must be unique ONLY within the same room type

ERROR 3: "Price must be greater than 0"
  └─ FIX: Enter a positive number
  └─ Try: 250000, 300000, 350000, etc.

ERROR 4: "Area must be greater than 0"
  └─ FIX: Enter a positive number
  └─ Try: 25, 30, 35, 40, etc.

ERROR 5: "Selected room type does not exist"
  └─ FIX: This is a database issue
  └─ Action: Contact support with details

ERROR 6: "Error creating room: [message]"
  └─ FIX: Database connection issue
  └─ Action: Read the [message] part
  └─ Try: Restart the application


🔍 STEP 5: TEST WITH VALID DATA
═══════════════════════════════════════════════════════════════════════════════

Try this exact sequence:

1. Run: dotnet run
2. Wait for: "Now listening on: http://localhost:5008"
3. Open: http://localhost:5008
4. Click: "Rooms"
5. Click: "Add New Room"

FILL FORM LIKE THIS:

┌──────────────────────────────────────────┐
│ Name: Room 401                          │
│ Room Type: [Click dropdown]             │
│            → Select "Single Room"       │
│ Price: 350000                           │
│ Area: 35                                │
│ Available: [Check the box]              │
│ Description: (leave empty is OK)        │
│                                          │
│ [CREATE ROOM Button]                    │
└──────────────────────────────────────────┘

7. Click "Create Room"
8. If error appears:
   - Screenshot the error
   - Copy error message exactly
   - Check developer console (F12)
   - Check application terminal
   - Send me all details


🔍 STEP 6: PROVIDE ME WITH DETAILS
═══════════════════════════════════════════════════════════════════════════════

To help you further, please provide:

1. SCREENSHOT of the error page:
   - Take screenshot when error appears
   - Show the entire form with error messages
   - Show any red text visible

2. BROWSER CONSOLE OUTPUT:
   - Press F12
   - Go to Console tab
   - Copy any error messages shown
   - Paste them to me

3. TERMINAL OUTPUT:
   - Copy any red error text from terminal
   - Look for exception stack traces
   - Paste the full error

4. FORM DATA YOU ENTERED:
   - Exact values you typed
   - Which dropdown option you selected
   - Whether you checked the availability box

5. EXACT ERROR MESSAGE:
   - Word-for-word what the error says
   - Include any error codes
   - Include any validation messages


🔍 QUICK CHECKLIST
═══════════════════════════════════════════════════════════════════════════════

Before you test, verify:

☑ Application is running (terminal shows "Now listening on")
☑ You can access http://localhost:5008
☑ Room Type dropdown shows options (Single Room, Double Room, Family Room)
☑ You can view the Room list page
☑ Create form loads without errors
☑ All form fields are visible and editable

WHEN CREATING ROOM:

☑ Name field: Filled with unique name
☑ Room Type dropdown: An option is SELECTED
☑ Price field: Filled with positive number
☑ Area field: Filled with positive number
☑ Description: Can be empty (optional)
☑ Availability: Can be checked or unchecked

AFTER CLICKING CREATE:

☑ Wait 2-3 seconds for response
☑ Look for success (redirects to room list)
☑ OR look for error message (red text on form)
☑ If error, read the message carefully
☑ Check what field/rule failed


═══════════════════════════════════════════════════════════════════════════════

NEXT: Please follow these steps and provide me with:

1. The EXACT error message you see
2. Which form field is highlighted in red (if any)
3. Browser console output (F12 → Console)
4. Terminal output where the error appears

Then I can provide you with the exact fix! 

═══════════════════════════════════════════════════════════════════════════════

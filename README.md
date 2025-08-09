===========================================================
TOYS COMPANY INTERNAL SYSTEM - INSTALLATION GUIDE
===========================================================

Project Type: C# WinForms Application  
Purpose: Internal system for managing toy company operations  
Repository: https://github.com/Bill-Yeung/ITP4915M-System-dev-project

-----------------------------------------------------------
PREREQUISITES
-----------------------------------------------------------

1. Install XAMPP
   - Download from: https://www.apachefriends.org/index.html
   - Start Apache and MySQL services via XAMPP Control Panel

2. Import the Database
   - Open phpMyAdmin (http://localhost/phpmyadmin)
   - Create a new database (e.g., `AY2425Class1AGroup1.sql`)
   - Import one of the SQL files from:
     https://github.com/Bill-Yeung/ITP4915M-System-dev-project/tree/main/IntegratedSystem_1A_Group_1/Server/Data
     - Recommended: `AY2425Class1AGroup1.sql'

3. Install Visual Studio Code
   - Download from: https://code.visualstudio.com/
   - Install C# extension (powered by OmniSharp)

-----------------------------------------------------------
RUNNING THE APPLICATION
-----------------------------------------------------------

1. Open the solution file:
   - `IntegratedSystem_1A_Group_1.sln` located in the root folder

2. Build and run the project:
   - Ensure all dependencies are restored
   - Configure database connection in `appsettings.json` if needed

3. Use the WinForms interface to interact with the system

-----------------------------------------------------------
TEST CUSTOMER ACCOUNTS
-----------------------------------------------------------

Use the following test accounts to log in:

| Customer ID | Name             | Email / Username       | Password (same as email) |
|-------------|------------------|------------------------|---------------------------|
| C00001      | Alice Smith      | alice@example.com      | alice@example.com         |
| C00002      | Bob Johnson      | bob@example.com        | bob@example.com           |
| C00003      | Charlie Brown    | charlie@example.com    | charlie@example.com       |
| C00004      | Diana Prince     | diana@example.com      | diana@example.com         |
| C00005      | Ethan Hunt       | ethan@example.com      | ethan@example.com         |
| C00006      | Fiona Gallagher  | fiona@example.com      | fiona@example.com         |
| C00007      | George Costanza  | george@example.com     | george@example.com        |
| C00008      | Hannah Baker     | hannah@example.com     | hannah@example.com        |
| C00009      | Ian Malcolm      | ian@example.com        | ian@example.com           |
| C00010      | Julia Roberts    | julia@example.com      | julia@example.com         |

🔐 Passwords are stored as SHA-256 hashes in the database, but for testing, use the email address as the password.

-----------------------------------------------------------
NOTES
-----------------------------------------------------------

- This system is intended for internal use only.
- Ensure your MySQL server is running before launching the application.
- For troubleshooting, check the `Server` project logs and connection strings.
Bill Yeung via GitHub Issues or project repository

===========================================================

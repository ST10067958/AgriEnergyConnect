Agri-Energy Connect – Web Application Prototype
-----------------------------------------------

📍 Background:
In response to South Africa’s growing need for sustainable agriculture and the integration of green energy, Agri-Energy Connect was conceptualised as a digital platform that bridges the gap between farmers and green technology providers. This prototype demonstrates how such a platform can function as a resource hub, collaboration space, and data-driven tool for empowering farmers and employees in the sector.

🎯 Purpose:
The prototype is a web-based system that allows employees to manage farmer profiles, and enables farmers to track and manage their product information. It lays the foundation for a future full-scale platform supporting green energy education, funding collaboration, and real-time agricultural data integration.

👥 User Roles:
1. **Farmer** – Can log in, add new products (with name, category, production date), and view their product history.
2. **Employee** – Can log in, create new farmer profiles, view all farmer products, and filter products by type or production date.

🔐 Demo Login Accounts:
- Farmer: `farmer1` / `1234`
- Employee: `employee1` / `1234`

💻 How to Set Up and Run:
1. Open the solution file `AgriEnergyConnect.sln` in **Visual Studio 2022**.
2. Open **Package Manager Console**, run:
   - `Add-Migration Init`
   - `Update-Database`
3. Press **F5** or click "Run" to launch the web application in your browser.
4. Login using the demo credentials above to explore the system.

🗃️ Technologies Used:
- ASP.NET Core MVC (.NET 8.0)
- Entity Framework Core with SQL Server LocalDB
- Bootstrap 5 & Bootstrap Icons
- C# Razor Views
- Server-side and client-side validation

🧪 Key Features Demonstrated:
- Secure, session-based login system
- Role-based dashboards (Employee vs Farmer)
- Form validation with clear error messages
- Filterable product list (by farmer, category, and date)
- Responsive UI using Bootstrap and professional icon styling
- Sample data seeded on first launch (can be removed for live use)

📂 Submission Notes:
- The prototype includes all required source code and database integration files.
- The system is pre-populated with realistic sample data to showcase core functionality.
- All major project features have been implemented and tested as per the provided rubric.

© 2025 – Developed for the Independent Institute of Education (IIE) POE Submission

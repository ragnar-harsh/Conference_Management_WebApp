# Online Conference Management System

## Overview
The Online Conference Management System is a web application designed using Angular for the frontend and ASP.NET Core Web API for the backend. It provides a secure and efficient way to manage conferences and meetings. The system includes user authentication with role-based access, where admins can manage meetings while normal users can view, accept, and provide feedback on meetings. The application integrates PostgreSQL for structured and secure data storage.

## Features
- **User Authentication & Authorization**
  - Secure user registration and login.
  - Role-based access control (Admin, Normal User).
  - JWT-based authentication for secure communication.
  
- **Meeting Management (Admin)**
  - Add, edit, and remove meetings.
  - Manage meeting details such as time, venue, and participants.
  
- **User Interaction (Normal User)**
  - View available meetings.
  - Accept or decline meeting invitations.
  - Provide feedback on meetings.
  
- **Database Integration**
  - PostgreSQL for structured and secure data storage.
  - Stores user data, meetings, feedback, and participant responses.
  
- **Security Measures**
  - CSRF protection and data encryption.
  - Secure API endpoints with authentication and authorization.
  
## Technologies Used
- **Frontend:** Angular
- **Backend:** ASP.NET Core Web API
- **Database:** PostgreSQL
- **Authentication:** JWT (JSON Web Token)

## Installation & Setup
### Frontend (Angular)
1. **Clone the Angular repository**
   ```sh
   git clone https://github.com/ragnar-harsh/Conference_Management_WebApp
   cd Online-Conference-Angular
   ```
2. **Install dependencies**
   ```sh
   npm install
   ```
3. **Run the application**
   ```sh
   ng serve
   ```
   Access the application at `http://localhost:4200/`.

### Backend (ASP.NET Core Web API)
1. **Clone the API repository**
   ```sh
   git clone https://github.com/ragnar-harsh/Conference_Management_WebApp
   cd Online-Conference-API
   ```
2. **Restore dependencies**
   ```sh
   dotnet restore
   ```
3. **Update database** (Ensure PostgreSQL is configured)
   ```sh
   dotnet ef database update
   ```
4. **Run the API server**
   ```sh
   dotnet run
   ```
   API available at `http://localhost:5000/`.

## Usage
- Users can register and log in to access the platform.
- Admins can create, update, and delete meetings.
- Normal users can view and accept meetings.
- Users can provide feedback after meetings.

## Contributing
Contributions are welcome! Feel free to submit issues or pull requests to improve the project.

## License
This project is licensed under the MIT License.

---
Made with ❤️ using Angular & ASP.NET Core.


## Search Box with Autocomplete Feature

This project implements a search box with autocomplete feature using ASP.NET Core 8 for the backend and HTML, JavaScript, and CSS for the frontend. It follows good practices such as N-tier architecture, singleton pattern, scoped services, rate limiting, DTOs, and Docker containerization.

### Technology Stack

- **Backend:** ASP.NET Core 8
- **Frontend:** HTML, JavaScript, CSS

### Architecture

- **N-tier architecture:** The application is divided into layers for better organization and separation of concerns.

### Design Patterns

- **Singleton pattern:** Utilized for the public hard-coded API to ensure there's only one instance of the object.

### Service Lifetime

- **Scoped services:** Services are scoped to ensure they are created once per request.

### Security

- **Rate limiter:** Implemented to control the rate of requests being made to the server, preventing abuse or overload.

### Data Transfer Objects (DTOs)

- Used for transferring data between different layers of the application, providing a clear separation of concerns and enhancing maintainability.

### Containerization

- **Docker:** Used for containerizing the application, making it easy to deploy and manage across different environments.

### Deployment

- **Docker Compose:** Used for defining and running multi-container Docker applications, simplifying the deployment process.

### Setup Instructions

1. **Clone Repository:**

   git clone https://github.com/amanuel-meketa/search_suggestion.git

2. **Navigate to Docker Compose File:**
- Open a terminal or command prompt and navigate to the directory containing the Docker Compose file.

3. **Run Docker Compose:**

4. **Access Swagger Documentation:**
- Visit [http://localhost:8080/swagger/index.html](http://localhost:8080/swagger/index.html) in your web browser.

5. **Run the UI:**
- Navigate to the `search_suggestion.ui` directory in your project.
- Run the index file (presumably an HTML file) in your preferred web browser to interact with the search box and autocomplete feature.



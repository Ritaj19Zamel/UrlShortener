# 🔗 URL Shortener API (.NET)

This is a backend-only URL shortening service built in **ASP.NET Core**. It allows users to submit a long URL and receive a shortened version, similar to services like [bit.ly](https://bit.ly) or [tinyurl](https://tinyurl.com). The shortened URLs can be used to redirect back to the original long URLs.

---

## 🚀 Features

- ✅ Shorten a long URL to a unique key (e.g., `/lnlpBJ`)
- ✅ Redirect a shortened key to the original URL
- ✅ Delete a previously shortened URL
- ✅ In-memory static dictionary storage (no database)
- ❌ No frontend UI (API-only)
- 🔒 No external dependencies (e.g. Redis, DBs, etc.)

---

## 📦 Tech Stack

- ASP.NET Core Web API
- C#
- In-memory storage (`Dictionary<string, string>`)

---

## 📂 Project Structure (Backend Only)

```bash
UrlShortener/
├── Controllers/
│   └── UrlController.cs       # Handles API endpoints
├── Services/
│   ├── IUrlService.cs         # Interface for URL service
│   ├── UrlService.cs          # Implementation for storage & logic
│   ├── IKeyGenerator.cs       # Interface for key generator
│   └── KeyGenerator.cs        # Hash-based key generator
├── Models/
│   └── UrlRequest.cs          # Model for POST body
│   └── UrlResponse.cs          # Model for GET response
├── Program.cs                 # Startup configuration
```
## ⚙️ Endpoints
### POST /shorten
Shortens a long URL.

#### 🔸 Request
```json
POST /shorten
Content-Type: application/json

{
  "url": "https://www.example.com"
}
```
#### 🔸 Response
```json
{
  "key": "lnlpBJ",
  "long_url": "https://www.example.com",
  "short_url": "http://localhost:7158/lnlpBJ"
}
```
### GET /{key}
Redirects the client to the original long URL.

#### 🧪 Example:
```bash
curl -L http://localhost:7158/lnlpBJ
```
Returns a 302 Found with Location header set to the original long URL.

If key does not exist:
```bash
curl -i http://localhost:7158/fakeKey
```
Response:
```http
HTTP/1.1 404 Not Found
URL not found
```
### DELETE /{key}
Deletes the shortened URL mapping.
#### 🧪 Example:
```bash
curl -X DELETE http://localhost:7158/lnlpBJ -i
```
#### Response:
```http
HTTP/1.1 200 OK
URL deleted successfully
```
If key does not exist:
```http
HTTP/1.1 404 Not Found
URL not found
```
## 🧪 Testing Notes
- To follow redirects in curl: curl -L
- If using https://localhost, you might need curl -k to ignore local certs.
- Swagger UI may show Failed to fetch on redirects — test redirects with curl or browser directly.

## 🛠️ Setup

1. **Clone the repository**

   ```bash
   git clone https://github.com/your-username/url-shortener.git
   cd url-shortener
   ```
2. Use Swagger at https://localhost:7158/swagger (adjust port as needed)

## ✏️ Possible Improvements
- Add persistent storage (e.g. SQLite, Redis)
- Add frontend UI for user-friendly interaction
- Add authentication and analytics (e.g. click count)
- Deploy to cloud with CI/CD (e.g. GitHub Actions + Azure/AWS)

## 📚 Challenge Source

This project was built as a solution to the [URL Shortener Challenge](https://codingchallenges.fyi/challenges/challenge-url-shortener/) from [codingchallenges.fyi](https://codingchallenges.fyi).

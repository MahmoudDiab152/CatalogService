# 📦 Catalog API

A **.NET Clean Architecture** Web API project that integrates with [Fake Store API](https://fakestoreapi.com/products) to provide product data with **pagination, searching, and sorting**.

---

## 🏗️ Architecture

This project follows **Clean Architecture** principles:

* **Domain (Catalog.Core)**

  * Entities, value objects, specifications (e.g. `ProductSpecification`, `Pagination<T>`).

* **Application (Catalog.Application)**

  * DTOs (`ProductDto`, `RatingDto`), interfaces (`IExternalProductService`).

* **Infrastructure (Catalog.Infrastructure)**

  * Implements external services (`ExternalProductService`) using `HttpClient`.

* **API (Catalog.API)**

  * ASP.NET Core Web API exposing endpoints.
  * Uses API versioning (`/api/v1/...`).
  * Swagger documentation included.

---

## 🚀 Features

* ✅ Fetches product data from external API: [Fake Store API](https://fakestoreapi.com/products)
* ✅ Supports **pagination** (`PageIndex`, `PageSize`)
* ✅ Supports **searching** (`Search` by product title)
* ✅ Supports **sorting** by:

  * `priceAsc`
  * `priceDesc`
  * `titleAsc`
  * `titleDesc`
* ✅ Returns data wrapped in a **Pagination DTO**

---

## 📖 API Documentation

Swagger UI is available at:

```
http://localhost:5242/swagger/index.html
```

### Example Endpoint

```
GET /api/v1/Products/GetAllProducts
```

### Query Parameters

| Name        | Type   | Description                                                    |
| ----------- | ------ | -------------------------------------------------------------- |
| `PageIndex` | int    | Page number (default = 1)                                      |
| `PageSize`  | int    | Items per page (max = 30)                                      |
| `Sort`      | string | Sorting key (`priceAsc`, `priceDesc`, `titleAsc`, `titleDesc`) |
| `Search`    | string | Search term (matches product title)                            |

---

### Example Request

```http
GET /api/v1/Products/GetAllProducts?PageIndex=1&PageSize=5&Sort=priceAsc&Search=shirt
```

### Example Response

```json
{
  "pageIndex": 1,
  "pageSize": 5,
  "count": 20,
  "data": [
    {
      "id": 1,
      "title": "Casual Shirt",
      "price": 25.99,
      "description": "A nice cotton shirt",
      "category": "men's clothing",
      "image": "https://fakestoreapi.com/img/1.jpg",
      "rating": {
        "rating": 4.5,
        "count": 120
      }
    }
  ]
}
```

---

## 🛠️ Setup & Run

### Prerequisites

* [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
* Visual Studio 

### Run the project

```bash
git clone https://github.com/MahmoudDiab152/CatalogService.git
cd CatalogService
dotnet build
dotnet run --project Catalog.API
```

Open in browser:
👉 `http://localhost:5242/swagger/index.html`

---

## 📌 References

* [Fake Store API](https://fakestoreapi.com/products)
* [Clean Architecture principles](https://github.com/jasontaylordev/CleanArchitecture)

---

👨‍💻 Author: **Mahmoud Diab**
📧 Email: [mahmouddiab152@gmail.com](mailto:mahmouddiab152@gmail.com)
🔗 GitHub: [MahmoudDiab152](https://github.com/MahmoudDiab152)



🛠️ This project is a .NET API for managing a stock portfolio, using MongoDB as the database. The API allows CRUD operations (Create, Read, Update, Delete) on stock entities, with each stock having properties like symbol, name, quantity, and price.


- Prerequisites

  * .NET SDK
  
  * MongoDB.Drivers package

🚀 Running Locally

- Update the appsettings.json file with your MongoDB connection details:

```bash
{
  "MongoDbSettings": {
    "ConnectionString": "mongodb://localhost:127.0.0.1",
    "DatabaseName": "StockPortfolioDb",
    "StocksCollectionName": "Stocks"
  }
}
``` 
- Restore Dependencies and Run the Project:
  
```bash
dotnet restore
dotnet run
``` 

  - Accessing the API:
  
    * The API will be available at https://localhost:PORT (PORT comes from when you run the dotnet RUN)
  
- API Endpoints
  
  - Get All Stocks
  
    **URL:**  /api/stocks
    
    **Method:**  GET
    
    **Description:**  Retrieves all stocks.
    
    **Response:** Returns a list of stocks.
  
  - Get Stock by ID
    
      **URL:** /api/stocks/{id}
    
      **Method:** GET
      
      **Description:** Retrieves a stock by its ID.
      
      **Parameters:** id (int): The ID of the stock.
      
      **Response:**  Returns the stock details.
    
    
  - Add a New Stock
      
      **URL:** /api/stocks 
    
      **Method:** POST
    
      **Description:** Adds a new stock to the portfolio. 
    
      ```bash
      {
        "symbol": "PETR4",
        "name": "Petrobras",
        "quantity": 10,
        "price": 37
      }
      ```

  - Update an Existing Stock
    
      **URL:** /api/stocks/{id}
    
      **Method:** PUT
    
      **Description:** Updates an existing stock.
    
      **Parameters:** id (int): The ID of the stock to update.
    
      **Request Body:**

     ```bash
      {
        
        "symbol": "PETR4",
        "name": "Petrobras",
        "quantity": 15,
        "price": 37
      }
      ```

  - Delete a Stock
    
        **URL:** /api/stocks/{id}
    
        **Method:**  DELETE
       
        **Description:**  Deletes a stock by its ID.
       
        **Parameters:** 
         **id (int):** The ID of the stock to delete.
 
         **Response:** Returns no content on success.
               





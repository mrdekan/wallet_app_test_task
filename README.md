# Wallet App Test Task

## Setup Instructions

To run the project, you need to create an `appsettings.json` file in the `WalletAPI` directory (next to `Program.cs`) and add the following content. **Note:** Be sure to fill in the `{your_db_username}` and `{your_password}` fields with your actual database credentials.

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Database=wallet;Username={your_db_username};Password={your_password}"
  }
}
```
To apply the database migrations, open your Package Manager Console in Visual Studio and run:   
```Update-Database```  

Or use the following command in your command line:   
```dotnet ef database update```

Start the project, then open [https://localhost:7014/swagger/index.html](https://localhost:7014/swagger/index.html) in your browser if it doesn't open automatically.

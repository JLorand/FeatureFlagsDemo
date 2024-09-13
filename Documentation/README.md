# Feature Flagging Demo

## Introduction
This is a simple web api to show how to use feature flagging in a simple web application.
The application deals with invoices. It returns a list of invoices in JSON format.

## The base application
Returns a list of invoices with the following fields:
```json
[
    {
        "items": [
            {
                "name": "Item 1",
                "quantity": 1,
                "price": 10,
                "subTotal": 10
            }
        ],
        "total": 10
    }
]
```
### Technologies used:
- **NET 8.0**
- **C# 10.0**
- **Swagger**: to document the API.
- **Entity Framework Core**: to connect to an in-memory database.
- **AutoMapper**: to map the entities to DTOs.


## Requirements
The application should be able to return the total price including taxes.

## Solution
The solution is to use a feature flag to enable the tax calculation feature. The feature flag is a boolean value that is stored in the appsettings.json file. The application checks the value of the tax percentage and calculates the total price accordingly.

## Sources
https://martinfowler.com/articles/feature-toggles.html
https://learn.microsoft.com/en-us/azure/azure-app-configuration/use-feature-flags-dotnet-core
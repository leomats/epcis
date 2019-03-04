[![Build Status](https://travis-ci.com/FasTnT/epcis.svg?branch=master)](https://travis-ci.com/FasTnT/epcis)

# FasTnT EPCIS

FasTnT EPCIS is a simple, lightweight GS1 EPCIS 1.2 repository written in C# using .NET Core 2.2, backed with PostGreSQL database.

## Setup

Prerequisites: 
- PostGreSQL 9.5 or higher
- .NET Core 2.2 SDK

Steps:
1. Download the source code, and create a new user/database in PostGreSQL for FasTnT ;
2. Update the connection string: `$ dotnet user-secrets set ConnectionStrings:FasTnT.Database "{your connectionstring}" -p src\FasTnT.Host\FasTnT.Host.csproj` ;
3. Start the repository with the command `$ dotnet run -p src\FasTnT.Host\FasTnT.Host.csproj` ;
4. Create the SQL schemas and tables: `curl -X POST http://localhost:54805/EpcisServices/1.2/Database/Migrate` ;
5. That's it! You have a properly working EPCIS 1.2 repository.

## HTTP Endpoints

### EPCIS endpoints:

The API is secured using HTTP Basic authentication. The default username:password value is `admin:P@ssw0rd`

- Capture: `POST /EpcisServices/1.2/Capture` 
- Queries : `POST /EpcisServices/1.2/Query`
- Subscription trigger : `GET /EpcisServices/1.2/Subscription/Trigger/{triggerName}`

**Capture** endpoint only supports requests with `content-type: application/xml` or `content-type: text/xml` header and XML payload.

**Queries** endpoint supports XML and SOAP requests. Note that it will not return the wsdl on a `GET` request. SOAP requests *must* contain a `content-type` header with value set to either `application/soap+xml` or `text/soap+xml`.

See the `documents\EPCIS_Samples.postman_collection.json` file for more informations and requests examples.

### Others endpoints:

- Database migration: `POST /EpcisServices/1.2/Database/Migrate`
- Database rollback: `POST /EpcisServices/1.2/Database/Rollback`

These database endpoints are only available when the EPCIS server is in Development configuration.

The file `documents\EPCIS_Samples.postman_collection.json` contains examples of HTTP requests that you can perform on FasTnT (import and run it in [PostMan](https://www.getpostman.com/))

## Implemented Features

- Capture
  - Events
  - Master Data (CBV)
- Queries:
  - GetVendorVersion
  - GetStandardVersion
  - GetQueryNames
  - GetSubsciptionIDs
  - Poll 
    - SimpleEventQuery
    - SimpleMasterDataQuery
- Query Callback:
  - CallbackResults
  - CallbackQueryTooLargeException
  - CallbackImplementationException
- Subscriptions:
  - Subscribe to an EPCIS request 
  - Unsubscribe from EPCIS repository
  - Trigger subscriptions that register to specific trigger name

# License

This project is licensed under the Apache 2.0 license - see the LICENSE file for details

Contact: fastnt@pm.me

_Last update: march 2019_

# SimpleBook
API to book service control and extremely simple front-end in razor

## Purpose
•	Implementation of one Web API method for clients to POST a new book. The URL to POST the new book should use the pattern api/book/create and the method should return the new book id back to the client.

•	Implementation of one Web API method for clients to PUT (update) an existing book. The URL to update the existing book should use the pattern api/book/{bookId}/update and the method should return the entire book structure back to the client.
Partial updates should be possible as the client may want to update some book fields but not all of them in the same PUT request.

•	Implementation of simple client application that will allow http interaction with the two Web API methods described above.

## Libraries / Frameworks / Language
* API has implemented in .NET 6 C#10, Razor for fron-end solution. It was developed in Visual Studio 2022 platform.
* Entity Framework IN MEMORY. This approach is used to avoid any extra instalation, since it is a demonstration.
* AutoMapper to control (here it was done the control for PATCH through PUT. This approach is used because all Book fields are mandatory.
* FluentValidation it is used to validade the entry object depends on the Http verb.
* Swagger (UI, Schema example, annotations).
* MsTest Framework Core and Moq Framework for Unit test.

## General concepts
This API follows SOLID principles to maintain decoupling and cohesion. It has just unit tests for controller methods to show you this approach and how easy it is to test specific methods when you use the DI principle.

## How to run
* Download the repository
* Using visual studio or COMMAND PROMPT:
  * You can run in develop mode the API where you have the Swagger UI presentation with already done example to test the API.
  * For you to run the WebApplication implemented you should access ta root path of the project "SimpleBookApi" through the COMMAND PROMPT and start de project by launching the command "dotnet run". It will show you the listening port.

  ![image](https://user-images.githubusercontent.com/35920145/156402854-64d1b3e6-3a92-458e-a7fe-579ddfd51d42.png)

  * After it, you can run the SimpleBookWebApp in Visual Studio or you can access the root path of the "SimpleBookWebApp" through the COMMAND PROMPT and launch the command "dotnet run", get the link created e put it in the browse. Well done!!!
   
  ![image](https://user-images.githubusercontent.com/35920145/156416178-99fd6d15-fe3f-4686-a905-7b8157d9b588.png)


#GraphQL
GraphQL is an api spec designed by facebook. It only defines how to define your API, it doesn't supply a library.
I'm mainly interested in using GraphQL for reading data, I won't dive into mutators.

The project (GraphQL project)[https://graphql-dotnet.github.io] has a library with the following main features that we will look into:
- Parsing graphql queries and executing the against a set of data
- Generating a graphql schema from annotated poco's and query implementations

It does not interact (out of the box) with any ORM or web stack. This means that we need other code to use it with EF or AspNetCore.

##Example projects
This solution provides 2 example setups
1. An api that implements it's own queries. Simulates how one would combine GraphQL to access backend services
1. An api that queries into a sqlite db using EF core

##Links
- GraphQL concepts https://graphql.org/learn/
- GraphQL for .Net https://graphql-dotnet.github.io
- GraphQL for aspnetcore https://github.com/graphql-dotnet/server (nuget pkg `GraphQL.Server.Transports.AspNetCore`)
- A guide on combining GraphQL with aspnetcore https://medium.com/volosoft/building-graphql-apis-with-asp-net-core-419b32a5305b
- Combining GraphQL with EF core https://github.com/SimonCropp/GraphQL.EntityFramework
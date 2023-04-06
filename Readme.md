# GameServerÞingí

This is just a fun .net project to see what's good in the land of Microsoft these days.
"GameServer" may get upgraded to [.net 8](https://dotnet.microsoft.com/en-us/download/dotnet/8.0) while it's still in pre-release just because.

## Colophon

- .net 7 project - requires [the .net sdk](https://dotnet.microsoft.com/en-us/download)
- Docker is used to define the container, but you can use [podman](https://podman.io) to run it
  - We'll always maintain podman compatibility
- A [Hasura](https://hasura.io) GraphQL server is used on top of a [PostgreSQL](https://www.postgresql.org) database.
  - For a simple score server this is a dumb choice and we know that. Don't @ me.

## License

[All rights reserved](https://en.wikipedia.org/wiki/All_rights_reserved) to Andrew Kehrig and Dan Andersen.

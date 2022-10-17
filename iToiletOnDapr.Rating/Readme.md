# The iToilet Rating service

Inspired by Seinfeld and George his famous toilet-book: https://www.youtube.com/watch?v=Pci_7o6cCbM

This service let's you rate a public bathroom.

## Running the service locally:
dapr run --app-id rating --app-ssl --app-port 7299 --dapr-grpc-port 60002 dotnet run

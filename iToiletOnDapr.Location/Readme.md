# The iToilet Location service

Inspired by Seinfeld and George his famous toilet-book: https://www.youtube.com/watch?v=Pci_7o6cCbM

This service let's you store the location of a public bathroom.

## Running the service locally:
dapr run --app-id location --app-ssl --app-port 7183 --dapr-grpc-port 60001 dotnet run
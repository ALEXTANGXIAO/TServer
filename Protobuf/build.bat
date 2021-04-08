@echo off
protoc --csharp_out=./CSharp SocketGameProtocol.proto
pause
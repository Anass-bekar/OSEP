# OSEP MSSQL TOOLS

This is a code collection I developed to tackle the osep labs.

## commands.txt: 
```
List of commands that I found useful during my journey.
```
## mssql-executer.cs:
```
C# Code to execute sql queries on an sql server.
usage: sqlexecuter.exe sqlserver database auth/impersonated/query "sqlquery if applicabale"
```
## mssql-hex-executer.cs:
```
C# Code to execute shell commands on an sql server.
usage: mssql-hex-executer.exe sqlserver database "cmd to execute"
```
## mssql-responder-connect.cs:
```
C# Code to trigger LLMNR poisoning.
usage: mssql-responder-connect.exe sqlserver database attackerIP.
```
Note that this repo represents what I found missing from the other osep repos on github , as the tools from other modules are vastly documented elsewhere.

Good luck!

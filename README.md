# web-shell
Simple console running powershell scripts.

Use arrows (up and down) to pick prewious commands.
use enter to run a command.

![image](https://user-images.githubusercontent.com/96321369/190933853-2e9bf6cf-675e-4996-846e-f80fcd8f5a6b.png)
![image](https://user-images.githubusercontent.com/96321369/190933861-41a74e6d-01bd-4ba0-afd2-732e7cfb8f5c.png)

To run this app just run it in Visual Studio.

Make sure that your connection string (WebShell/WebShell.WebAPI/appsettings.json) is correct. By default it connects to local DB without any password
and creates "CommandsDB" database with "Commands" table.
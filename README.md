# StartupRabbitMQ
How to run this solution
1. Install Docker Desktop at Windows or Linux environment.
2. Run RabbitMQ in Docker 
   docker run -d --name rabbitmq -p 5672:5672 -p 15672:15672 rabbitmq:3.11-management
3. Install Dotnet sdk 6.0
4. Install Visual Studio Code
5. Pull this project
6. Build solution
   dotnet build
7. Run publisher
   cd Publisher
   dotnet run
   typing anthing you want to send to subscriber
8. Open browser, navigate to http://rabbitmq-ip:15672
   by default, use Username: guest & Password: guest to login RabbitMQ
9. Click Queues tab, you will see a BasicTest Quene name that contains message you publish in step 7.
10. Open another command prompt, change directory to subscribe sub folder
11. Run Subscribe
    dotnet run
12. You will see the messages you published in step 7.

FROM mcr.microsoft.com/dotnet/sdk:5.0
COPY . /app
WORKDIR /app
RUN ["dotnet", "restore"]
RUN ["dotnet", "build"]
ENV ASPNETCORE_URLS=http://+:80  
EXPOSE 80
RUN chmod +x ./entrypoint.sh
CMD /bin/bash ./entrypoint.sh
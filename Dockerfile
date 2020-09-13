# use alpine linux distributive with installed golang
FROM golang:alpine AS build

# install gcc g++ make and git
RUN apk --no-cache add gcc g++ make git

# COPY to /go/src/app directory of container golang project related files
WORKDIR /go/src/app
COPY ./main.go .
COPY ./go.mod .
COPY ./go.sum .
COPY ./v1 .

# build golang project
RUN GOOS=linux go build -ldflags="-s -w" -o ./bin/plando ./main.go

# use alpine linux distributive for runing build at port 1323
FROM alpine:3.9
WORKDIR /usr/bin
COPY --from=build /go/src/app/bin/plando /go/bin/plando
EXPOSE 1323
ENTRYPOINT /go/bin/plando --port 1323

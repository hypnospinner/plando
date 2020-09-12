FROM golang:alpine AS build
RUN apk --no-cache add gcc g++ make git
WORKDIR /go/src/app
COPY . .
RUN GOOS=linux go build -ldflags="-s -w" -o ./bin/plando ./main.go

FROM alpine:3.9
WORKDIR /usr/bin
COPY --from=build /go/src/app/bin/plando /go/bin/plando
EXPOSE 1323
ENTRYPOINT /go/bin/plando --port 1323

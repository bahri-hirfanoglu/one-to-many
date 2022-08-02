package main

import (
	"fmt"
	"log"

	"github.com/bahri-hirfanoglu/go-socketio/server"
	"github.com/joho/godotenv"
)

func main() {
	err := godotenv.Load()
	if err != nil {
		log.Fatal("Error loading .env file")
	}
	fmt.Println("Server Running...")
	server.CreateServer()

}

package main

import (
	"log"

	"github.com/bahri-hirfanoglu/go-socketio/server"
	"github.com/fatih/color"
	"github.com/joho/godotenv"
)

func main() {
	err := godotenv.Load()
	if err != nil {
		log.Fatal("Error loading .env file")
	}
	color.Cyan("Server is running...")
	server.CreateServer()

}

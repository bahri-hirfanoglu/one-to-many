package main

import (
	"fmt"

	"github.com/bahri-hirfanoglu/go-socketio/helper"
	"github.com/bahri-hirfanoglu/go-socketio/server"
)

func main() {
	fmt.Println("Server Running...")
	server.CreateServer()
	helper.LoadServerData()
}

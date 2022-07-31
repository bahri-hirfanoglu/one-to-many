package server

import (
	"fmt"
	"net"
	"os"

	"github.com/bahri-hirfanoglu/go-socketio/command"
	"github.com/bahri-hirfanoglu/go-socketio/helper"
)

func CreateServer() {
	server, err := net.Listen(helper.Getenv("SERVER_TYPE", "tcp"), helper.Getenv("SERVER_HOST", "localhost")+":"+helper.Getenv("SERVER_PORT", "5555"))
	if err != nil {
		fmt.Println("Error listening:", err.Error())
		os.Exit(1)
	}
	defer server.Close()
	fmt.Println("Listening on " + helper.Getenv("SERVER_HOST", "localhost") + ":" + helper.Getenv("SERVER_PORT", "5555"))
	fmt.Println("Waiting for client...")

	for {
		connection, err := server.Accept()
		if err != nil {
			fmt.Println("Error accepting: ", err.Error())
			os.Exit(1)
		}
		fmt.Println("client connected")
		go processClient(connection)
	}
}

func processClient(connection net.Conn) {
	buffer := make([]byte, 1024)
	mLen, err := connection.Read(buffer)
	if err != nil {
		fmt.Println("Error reading:", err.Error())
	}
	var message = string(buffer[:mLen])
	var result = command.RunCommand(message)
	_, _ = connection.Write([]byte(result))
	connection.Close()
}

package server

import (
	"net"
	"os"

	"github.com/bahri-hirfanoglu/go-socketio/command"
	"github.com/bahri-hirfanoglu/go-socketio/helper"
	"github.com/fatih/color"
)

func CreateServer() {
	server, err := net.Listen(helper.Getenv("SERVER_TYPE", "tcp"), helper.Getenv("SERVER_HOST", "127.0.0.1")+":"+helper.Getenv("SERVER_PORT", "5555"))
	if err != nil {
		color.Red("Error listening:", err.Error())
		os.Exit(1)
	}
	defer server.Close()
	color.Cyan("Listening on %s:%s", helper.Getenv("SERVER_HOST", "127.0.0.1"), helper.Getenv("SERVER_PORT", "5555"))
	color.Cyan("Waiting for client...")

	for {
		connection, err := server.Accept()
		if err != nil {
			color.Red("Error accepting: ", err.Error())
			os.Exit(1)
		}
		go processClient(connection)
	}
}

func processClient(connection net.Conn) {
	buffer := make([]byte, 1024)
	mLen, err := connection.Read(buffer)
	if err != nil {
		color.Red("Error reading:", err.Error())
	}
	var message = string(buffer[:mLen])
	var result = command.RunCommand(message)
	_, _ = connection.Write([]byte(result))
	connection.Close()
}

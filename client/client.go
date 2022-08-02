package client

import (
	"bufio"
	"fmt"
	"net"

	"github.com/bahri-hirfanoglu/go-socketio/helper"
)

func SendClient(serverIP, serverPort, message string) {
	conn, err := net.Dial(helper.Getenv("CLIENT_TYPE", "tcp"), serverIP+":"+serverPort)
	if err == nil {
		fmt.Fprintf(conn, message+"\n")
		bufio.NewReader(conn).ReadString('\n')
		conn.Close()
	}
}

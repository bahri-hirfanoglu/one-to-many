package command

import (
	"encoding/json"
	"fmt"

	"github.com/bahri-hirfanoglu/go-socketio/client"
	"github.com/bahri-hirfanoglu/go-socketio/helper"
)

func RunCommand(data string) (result string) {
	fmt.Println(data)
	result = "unknown command"
	servers := helper.LoadServerData()
	commands := parseCommand(data)
	switch commands["CommandName"] {
	case "sendMessage":
		otherServers := helper.GetOtherServer(servers, "s1")
		for _, item := range otherServers {
			cmdJson, _ := json.Marshal(commands)
			fmt.Println(item.Ip, item.Port, string(cmdJson))
			go client.SendClient(item.Ip, item.Port, string(cmdJson))
		}
		result = "command: " + commands["name"]
	}
	return result
}

func parseCommand(val string) map[string]string {
	data := map[string]string{}
	json.Unmarshal([]byte(val), &data)
	return data
}

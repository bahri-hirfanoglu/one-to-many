package command

import (
	"encoding/json"

	"github.com/bahri-hirfanoglu/go-socketio/client"
	"github.com/bahri-hirfanoglu/go-socketio/helper"
	"github.com/fatih/color"
)

func RunCommand(data string) (result string) {
	result = "unknown command"
	servers := helper.LoadServerData()
	commands := parseCommand(data)
	switch commands["CommandName"] {
	case "sendMessage":
		otherServers := helper.GetOtherServer(servers, commands["Server"])
		for _, item := range otherServers {
			cmdJson, _ := json.Marshal(commands)
			color.Green("Server: %s: %s:%s send package: %s", item.Id, item.Ip, item.Port, commands["CommandName"])
			client.SendClient(item.Ip, item.Port, string(cmdJson))
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

package command

import (
	"encoding/json"
	"fmt"
)

func RunCommand(data string) string {
	//var serverlist = helper.LoadServerData()
	commands := parseCommand(data)
	switch commands["name"] {
	case "sendMessage":
		fmt.Println("getMessage")
	}
	return ""
}

func parseCommand(val string) map[string]string {
	data := map[string]string{}
	json.Unmarshal([]byte(val), &data)
	return data
}

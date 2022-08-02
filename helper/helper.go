package helper

import (
	"encoding/json"
	"io/ioutil"
	"os"

	"github.com/bahri-hirfanoglu/go-socketio/model"
)

func Getenv(key, fallback string) string {
	value := os.Getenv(key)
	if len(value) == 0 {
		return fallback
	}
	return value
}

func LoadServerData() model.ServerList {
	file, _ := ioutil.ReadFile("data/server.json")
	data := model.ServerList{}
	_ = json.Unmarshal([]byte(file), &data)
	return data
}

func GetServer(arr model.ServerList, val string) (out model.Server) {
	for _, each := range arr.ServerList {
		if each.Id == val {
			out = each
			break
		}
	}
	return out
}

func GetOtherServer(arr model.ServerList, val string) (out []model.Server) {
	for _, each := range arr.ServerList {
		if each.Id != val {
			out = append(out, each)
		}
	}
	return out
}

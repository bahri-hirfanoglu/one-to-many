package model

type Server struct {
	Id   string `json:"ID"`
	Ip   string `json:"IP"`
	Port string `json:"PORT"`
}

type ServerList struct {
	ServerList []Server `json:"server_list"`
}

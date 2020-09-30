package main

import (
	"fmt"
	"os"

	"github.com/hypnospinner/plando/v1/config"
)

func main() {
	var config config.AppConfig

	os.Setenv("ENV", "test")
	defer os.Unsetenv("ENV")

	config.ReadConfigurationFile("./config/")

	fmt.Println(config)

}

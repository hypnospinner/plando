package config

import (
	"fmt"
	"os"

	"github.com/kelseyhightower/envconfig"
	"gopkg.in/yaml.v2"
)

// AppConfig contains information about entire application configuration
type AppConfig struct {
	API struct {
		Port string `yaml:"port" envconfig:"SERVER_PORT"`
		Host string `yaml:"host" envconfig:"SERVER_HOST"`
	} `yaml:"server"`
	Database struct {
		Host     string `yaml:"host" envconfig:"DB_HOST"`
		Port     string `yaml:"port" envconfig:"DB_PORT"`
		Username string `yaml:"username" envconfig:"DB_USERNAME"`
		Password string `yaml:"password" envconfig:"DB_PASSWORD"`
		Database string `yaml:"database" envconfig:"DB_NAME"`
	} `yaml:"database"`
}

// ReadConfigurationFile inserts configuration to config object from `.yml` file
func (cfg *AppConfig) ReadConfigurationFile(path string) {
	f, err := os.Open(fmt.Sprintf("%s/config.%s.yml", path, os.Getenv("ENV")))

	if err != nil {
		// TODO replace with generally used logger
		fmt.Println(err)
		os.Exit(2)
	}

	defer f.Close()

	decoder := yaml.NewDecoder(f)

	err = decoder.Decode(cfg)

	if err != nil {
		// TODO replace with generally used logger
		fmt.Println(err)
		os.Exit(2)
	}
}

// ReadEnvironmentConfiguration inserts information about config from env variables
func (cfg *AppConfig) ReadEnvironmentConfiguration() {
	err := envconfig.Process("", cfg)

	if err != nil {
		// TODO replace with generally used logger
		fmt.Println(err)
		os.Exit(2)
	}
}

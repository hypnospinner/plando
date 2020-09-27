package models

import (
	"github.com/hypnospinner/plando/v1/models/abstract"
	"gorm.io/gorm"
)

// Service describes what work we can perform for client
type Service struct {
	gorm.Model
	abstract.Event
	ID    uint
	Title string
	Price float32
}

package models

import (
	"github.com/hypnospinner/plando/v1/models/abstract"
	"gorm.io/gorm"
)

// OrderCreatedEvent describes
type OrderCreatedEvent struct {
	gorm.Model
	abstract.Event
	ID       uint
	ClientID uint
	Title    string
}

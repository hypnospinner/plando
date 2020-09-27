package models

import (
	"github.com/hypnospinner/plando/v1/models/abstract"
	"gorm.io/gorm"
)

// OrderPassedEvent describes event when client picked completed piece of work
type OrderPassedEvent struct {
	gorm.Model
	abstract.Event
	ID      uint
	OrderID uint
}

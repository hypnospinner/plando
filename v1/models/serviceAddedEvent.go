package models

import (
	"github.com/hypnospinner/plando/v1/models/abstract"
	"gorm.io/gorm"
)

// ServiceAddedEvent describes the service which client picked
// to be done in one's order
type ServiceAddedEvent struct {
	gorm.Model
	abstract.Event
	ID        uint
	ServiceID uint
	OrderID   uint
}

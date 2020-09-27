package models

import (
	"github.com/hypnospinner/plando/v1/models/abstract"
	"gorm.io/gorm"
)

// ServiceCompletedEvent describes an event
// when some service was done by laundry
type ServiceCompletedEvent struct {
	abstract.Event
	gorm.Model
	ID        uint
	ServiceID uint
}

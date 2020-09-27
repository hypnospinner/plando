package models

import (
	"github.com/hypnospinner/plando/v1/models/abstract"
	"gorm.io/gorm"
)

// ServiceRemovedEvent describes an event 
// when client cancelled some service to be done
type ServiceRemovedEvent struct {
	gorm.Model
	abstract.Event
	ID        uint
	ServiceID uint
}

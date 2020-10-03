package models

import (
	"time"

	guid "github.com/google/uuid"
	"gorm.io/gorm"
)

type ServiceRemovedEvent struct {
	gorm.Model
	ID        guid.UUID
	ServiceID guid.UUID // id of the ServiceAddedEvent
	At        time.Time
}

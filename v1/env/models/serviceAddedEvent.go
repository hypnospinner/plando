package models

import (
	"time"

	guid "github.com/google/uuid"
	"gorm.io/gorm"
)

type ServiceAddedEvent struct {
	gorm.Model
	ID        guid.UUID
	ServiceID guid.UUID
	OrderID   guid.UUID
	At        time.Time
}

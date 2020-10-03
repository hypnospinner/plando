package models

import (
	"time"

	guid "github.com/google/uuid"
	"gorm.io/gorm"
)

type ServiceCompletedEvent struct {
	gorm.Model
	ID guid.UUID
	At time.Time
}

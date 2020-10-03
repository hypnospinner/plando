package models

import (
	"time"

	guid "github.com/google/uuid"
	"gorm.io/gorm"
)

type OrderPassedEvent struct {
	gorm.Model
	ID      guid.UUID
	OrderID guid.UUID
	At      time.Time
}

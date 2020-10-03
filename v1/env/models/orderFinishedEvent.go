package models

import (
	"time"

	guid "github.com/google/uuid"
	"gorm.io/gorm"
)

type OrderFinishedEvent struct {
	gorm.Model
	ID      guid.UUID
	OrderID guid.UUID
	At      time.Time
}

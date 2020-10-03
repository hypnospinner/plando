package models

import (
	"time"

	guid "github.com/google/uuid"
	"gorm.io/gorm"
)

type OrderCreatedEvent struct {
	gorm.Model
	ID       guid.UUID
	ClientID guid.UUID
	Title    string
	At       time.Time
}

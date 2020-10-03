package models

import (
	guid "github.com/google/uuid"
	"gorm.io/gorm"
)

type ServiceAvailability struct {
	gorm.Model
	ID        guid.UUID
	ServiceID guid.UUID
	LaundryID guid.UUID
}

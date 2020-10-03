package models

import (
	guid "github.com/google/uuid"
	"gorm.io/gorm"
)

type Laundry struct {
	gorm.Model
	ID        guid.UUID
	Address   string
	ManagerID guid.UUID
}

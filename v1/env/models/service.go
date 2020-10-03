package models

import (
	guid "github.com/google/uuid"
	"gorm.io/gorm"
)

type Service struct {
	gorm.Model
	ID    guid.UUID
	Title string
	Price float32
}

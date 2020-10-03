package models

import (
	guid "github.com/google/uuid"
	"gorm.io/gorm"
)

type User struct {
	gorm.Model
	ID       guid.UUID
	Name     string
	Login    string
	Password string
	Role     Role
}

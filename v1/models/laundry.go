package models

import (
	"gorm.io/gorm"
)

// Laundry conteins some basic information about actual laundry
type Laundry struct {
	gorm.Model
	ID       uint
	Address  string
	MangerID uint
}

package models

import "gorm.io/gorm"

// User describes basically any user of our system
type User struct {
	gorm.Model
	ID       uint
	Name     string
	Login    string
	Password string
	Role     UserRole
}

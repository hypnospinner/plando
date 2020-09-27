package models

// UserRole is enum for different roles for users in service
type UserRole uint

// values for enum UserRole
const (
	Client        UserRole = 1
	Manager       UserRole = 2
	Administrator UserRole = 3
)

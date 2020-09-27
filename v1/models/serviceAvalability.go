package models

import "gorm.io/gorm"

// ServiceAvailability links service and laundries
// which describes which services laundry can provide
type ServiceAvailability struct {
	gorm.Model
	ID        uint
	ServiceID uint
	LaundryID uint
}

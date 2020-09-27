package models

import (
	"gorm.io/gorm"
	"github.com/hypnospinner/plando/v1/models/abstract"
)

// OrderFinishedEvent describes event of finishing order which 
// means laundry have done work, but client haven't picked the work yet
type OrderFinishedEvent struct {
	gorm.Model
	abstract.Event
	ID      uint
	OrderID uint
}

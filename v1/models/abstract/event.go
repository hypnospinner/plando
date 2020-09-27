package abstract

import (
	"time"
)

// Event is abstract base struct for any kind of event in the system
type Event struct {
	At time.Time
}

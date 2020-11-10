from django.db import models
import server.domain.events.orderCreatedEvent as orderCreatedEvent
from datetime import datetime


class OrderFinishedEvent(models.Model):
    orderId = models.ForeignKey(orderCreatedEvent.OrderCreatedEvent, on_delete=models.CASCADE)
    at = models.DateTimeField(default=datetime.today())
    

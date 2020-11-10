import server.domain.events.serviceAddedEvent as serviceAddedEvent
import server.domain.entities.order as order
from datetime import datetime
from django.db import models


class ServiceRemovedEvent(models.Model):
    serviceId = models.ForeignKey(serviceAddedEvent.ServiceAddedEvent, on_delete=models.CASCADE)
    orderId =models.ForeignKey(order.Order, on_delete=models.CASCADE)
    at = models.DateTimeField(default=datetime.today())
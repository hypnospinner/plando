import server.domain.entities.service as service
import server.domain.entities.order as order
from datetime import datetime
from django.db import models


class ServiceAddedEvent(models.Model):
    serviceId = models.ForeignKey(service.Service, on_delete=models.CASCADE)
    orderId =models.ForeignKey(order.Order, on_delete=models.CASCADE)
    at = models.DateTimeField(default=datetime.today())
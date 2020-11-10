import server.domain.events.serviceAddedEvent as serviceAddedEvent
from datetime import datetime
from django.db import models


class ServiceCompletedEvent(models.Model):
    serviceId = models.ForeignKey(serviceAddedEvent.ServiceAddedEvent, on_delete=models.CASCADE)
    at = models.DateTimeField(default=datetime.today()) 

from django.db import models
import server.domain.entities.user as user
from datetime import datetime

class OrderCreatedEvent(models.Model):
    clientId = models.ForeignKey(user.User, on_delete = models.CASCADE)
    title = models.CharField(default = '')
    at = models.DateTimeField(default = datetime.today())

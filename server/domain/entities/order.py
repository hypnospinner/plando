from django.db import models
import server.domain.entities.user as user
import server.domain.entities.service as service
import server.domain.entities.laundry as laundry


class Order(models.Model):
    services = models.TextField(default='')
    clientId = models.ForeignKey(user.User, on_delete=models.CASCADE)
    laundryId = models.ForeignKey(user.User, on_delete=models.CASCADE)
    state = models.IntegerField(default=0)
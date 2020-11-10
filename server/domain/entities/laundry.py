from django.db import models
import server.domain.entities.user as user

class Laundry(models.Model):
    address = models.TextField(default='')
    managerId = models.ForeignKey(user.User, on_delete=models.CASCADE)
    


from django.db import models

class User(models.Model):
    name = models.CharField(default='')
    login = models.CharField(default='')
    password = models.CharField(default='')
    role = models.IntegerField(default=0)

    


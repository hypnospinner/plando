from django.db import models

class Service(models.Model):
    title = models.CharField(default='')
    price = models.DecimalField(default = 0)

    

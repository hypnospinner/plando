from django.db import models
import server.domain.entities.service as service
import server.domain.entities.laundry as laundry

class serviceAvailability(models.Model):
    serviceId = models.ForeignKey(service.Service, on_delete= models.CASCADE)
    laundryId = models.ForeignKey(laundry.Laundry, on_delete= models.CASCADE)



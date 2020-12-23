import {Laundry} from '@app/_models/laundry';
import {Service} from '@app/_models/service';

export class EnabledService{
  laundry: Laundry;
  laundryId: number;
  service: Service;
  serviceId: number;
}

import {Order} from '@app/_models/order';
import {User} from '@app/_models/user';
import {EnabledService} from '@app/_models/enabled_service';

export class Laundry {
  id: number;
  address: string;
  orders: Order[];
  services: EnabledService[];
  managers: User;
}

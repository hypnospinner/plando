import { Role } from './role';
import {Order} from '@app/_models/order';
import {Service} from '@app/_models/service';
import {User} from '@app/_models/user';

export class Laundry {
  id: number;
  address: string;
  orders: Order[];
  services: Service[];
  managers: User;
}

import { Service } from '@app/_models/service';
import {ServiceInOrder} from '@app/_models/serviceInOrder';

export enum Status {
  new,
  inProgress ,
  finished,
  passed,
}

export class Order {
  id: number;
  laundryId: number;
  clientId: number;
  title: string;
  status: string;
  price: number;
  services: ServiceInOrder[];
}

import { Service } from '@app/_models/service';

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
  services: Service[];
}

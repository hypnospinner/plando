import { Service } from '@app/_models/service';

enum Status {
  waiting,
  inProgress ,
  passed,
}

export class Order {
  id: number;
  laundryId: number;
  clientId: number;
  title: string;
  status: Status;
  price: number;
  services: Service[];
}

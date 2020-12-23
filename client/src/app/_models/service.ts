import {Laundry} from '@app/_models/laundry';

export class Service {
  id: number;
  title: string;
  laundries: Laundry[];
  price: number;
  serviceAddedEvents: any;
}

import { Role } from './role';

export class User {
    id: number;
    firstName: string;
    lastName: string;
    email: string;
    role: Role;
    token?: string;
}

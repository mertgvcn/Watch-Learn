import { Roles } from "../enumerators/Roles";

export interface UserDTO {
    id: number;
    firstName: string,
    lastName: string,
    email: string,
    phoneNumber: string,
    role: Roles
}
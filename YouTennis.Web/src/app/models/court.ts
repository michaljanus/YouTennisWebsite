import { Resource } from './resource';



export class Court extends Resource{
     clubId: number;
     city: string;
     zipCode: string;
     street: string;
     streetNumber: string;
     hourPrice: string;
     image: string;
}
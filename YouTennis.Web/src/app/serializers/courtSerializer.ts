import { Court } from '../models/court';
import { Capability } from 'protractor';
import { ISerializer } from './ISerializer';


export class CourtSerializer implements ISerializer {
    fromJson(json: any): Court {
      const court = new Court();
      court.id = json.id;
      court.clubId = json.clubId;
      court.city = json.city;
      court.zipCode = json.zipCode;
      court.street = json.street;
      court.streetNumber = json.streetNumber;
      court.hourPrice = json.hourPrice;
      court.image = json.image;

      return court;
    }

    toJson(court: Court): any {
      return {
        id: court.id,
        clubId: court.clubId,
        city: court.city,
        zipCode: court.zipCode,
        street: court.street,
        streetNumber: court.streetNumber,
        hourPrice: court.hourPrice,
        image: court.image
      };
    }
  }

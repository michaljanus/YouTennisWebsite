import { Club } from '../models/club';
import { ISerializer } from './ISerializer';

export class ClubSerializer implements ISerializer {
    fromJson(json: any): Club {
      const club = new Club();
      club.id = json.id;
      club.name = json.name;

      return club;
    }

    toJson(club: Club): any {
      return {
        id: club.id,
        name: club.name
      };
    }
  }

import { Resource } from '../models/resource';

export interface ISerializer {
    fromJson(json: any): Resource;
    toJson(resource: Resource): any;
}
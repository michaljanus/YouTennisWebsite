import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ConfigService {
  private apiUrl: string;
  private scope: string;
  private clientId: string;
  private clientSecret: string;

  constructor() {
    // this.apiUrl = 'https://localhost:44327/';
    this.apiUrl = 'https://youtennisapi.azurewebsites.net/';
    this.scope = 'YouTennis openid';
    this.clientId = 'YouTennis.API';
    this.clientSecret = 'VerySecretSecret';
  }

  getApiURI() {
    return this.apiUrl;
  }

  getScope() {
    return this.scope;
  }

  getClientId() {
    return this.clientId;
  }

  getClientSecret() {
    return this.clientSecret;
  }

}

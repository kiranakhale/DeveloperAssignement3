import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Customer } from './models/customer';


@Injectable()
export class ApiService {
  apiURL: string = 'api/customer';

  constructor(private httpClient: HttpClient) {

  }

  public createTraining(customer: Customer) {
    return this.httpClient.post(`${this.apiURL}/create`, customer,
      { responseType: 'text' });
  }

}

import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Training } from './models/training';


@Injectable()
export class ApiTrainingService {
  apiURL: string = 'api/training';

  constructor(private httpClient: HttpClient) {

  }

  public addTraining(training: Training) {
    return this.httpClient.post(`${this.apiURL}/addtraining`, training,
      { responseType: 'text' });
  }

}

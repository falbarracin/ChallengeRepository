import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Response } from "@angular/http";
import { Observable } from 'rxjs';
import 'rxjs/add/operator/map';
import {urlService} from '../app.config';

@Injectable()
export class UserService {

  constructor(private http: HttpClient) { }

  GetUsers() {
    return this.http.get(urlService);
  }

}

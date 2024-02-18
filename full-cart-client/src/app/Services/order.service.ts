import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment.development';

@Injectable({
  providedIn: 'root'
})
export class OrderService {

  baseUrl = environment.appUrl;

  constructor(private http : HttpClient) { }

  placeOrder(model:any) {
    this.http.post(this.baseUrl + 'order',model);
  }
}

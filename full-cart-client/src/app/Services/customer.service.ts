import { Injectable } from '@angular/core';
import { Customer } from '../Models/customer';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment.development';
import { map, of } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CustomerService {

  baseUrl = environment.appUrl;

  customers : Customer[] = [];

  constructor(private http : HttpClient) { }

  getCustomers() {
    if(this.customers.length > 0) return of(this.customers);
    return this.http.get<Customer[]>(this.baseUrl + 'users').pipe(
      map(customers => {
        this.customers = customers;
        return customers;
      })
    )

  }

  getCustomer(username : string) {
    const customer = this.customers.find(x => x.username === username);
    if(customer) return of(customer);
    return this.http.get<Customer>(this.baseUrl + 'users/' + username);
  }

  updateCustomer(customer : Customer) {
    return this.http.put(this.baseUrl + 'users', customer).pipe(
      map(() => {
        const index = this.customers.indexOf(customer);
        this.customers[index] = {...this.customers[index], ...customer}
      })
    )
  }

  setMainPhoto(photoId : number) {
    return this.http.put(this.baseUrl + 'users/set-main-photo/' + photoId, {});
  }

  deletePhoto(photoid : number) {
    return this.http.delete(this.baseUrl + 'users/delete-photo/' + photoid);
  }
}


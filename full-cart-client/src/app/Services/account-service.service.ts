import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, map } from 'rxjs';
import { environment } from 'src/environments/environment.development';
import { User } from '../Models/user';

@Injectable({
  providedIn: 'root'
})
export class AccountServiceService {

  baseUrl = environment.appUrl;

  private currentUserSource = new BehaviorSubject<User | null>(null);
  currentUser$ = this.currentUserSource.asObservable();

  constructor(private http : HttpClient) { }

  register(model : any) {
    return this.http.post<User>(this.baseUrl + 'account/register', model).pipe(
      map( (response: User) => {
        const user = response;
        if(user) {
          this.setCurrentUser(user);
        }
      }

      )
    )
  }

  setCurrentUser(user : User){
    localStorage.setItem('user', JSON.stringify(user));
    this.currentUserSource.next(user);
  }
}

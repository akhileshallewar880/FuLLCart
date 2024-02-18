import { Component, OnInit } from '@angular/core';
import { AccountServiceService } from './Services/account-service.service';
import { User } from './Models/user';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{
  
  title = 'FullCart';

  constructor(private accountService : AccountServiceService, private http : HttpClient) {
    
  }
  
  ngOnInit(): void {
    this.setCurrentUser();
  }

  setCurrentUser() {
    const userString = localStorage.getItem('user');
    if(!userString) return;

    const user : User = JSON.parse(userString);
    this.accountService.setCurrentUser(user);
  }
}

import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { User } from 'src/app/Models/user';
import { AccountServiceService } from 'src/app/Services/account-service.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit{
  user : User | undefined;

  constructor(public accountService : AccountServiceService, private router : Router) {
    
  }

  ngOnInit(): void {
    
  }

  logout(){
    this.accountService.logout();
    this.router.navigateByUrl('/login')
  }



}

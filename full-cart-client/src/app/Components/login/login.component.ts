import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AccountServiceService } from '../../Services/account-service.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit{
  
  loginForm : FormGroup = new FormGroup({});

  constructor(private fb : FormBuilder, private router : Router, private accountService : AccountServiceService) {
    
  }

  ngOnInit(): void {
    this.initializeForm()
  }

  initializeForm() {
    this.loginForm = this.fb.group({
      username : ['', Validators.required],
      password : ['', [Validators.required]],
    })
  }

  login(){
    this.accountService.login(this.loginForm.value).subscribe({
      next : () => {
        this.router.navigateByUrl('/')
      },
      error : (err) => console.log(err)
      
    })
  }
}

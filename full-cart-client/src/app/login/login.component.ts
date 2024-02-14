import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit{

  @Output() signUpForm = new EventEmitter<boolean>();
  
  loginForm : FormGroup = new FormGroup({});

  constructor(private fb : FormBuilder, private router : Router) {
    
  }

  ngOnInit(): void {
    this.initializeForm()
  }

  signUpPage(Event: any){
    this.signUpForm.emit(true);
  }

  initializeForm() {
    this.loginForm = this.fb.group({
      username : ['', Validators.required],
      password : ['', [Validators.required]],
    })
  }

  login(){
    this.router.navigateByUrl('/')
  }
}

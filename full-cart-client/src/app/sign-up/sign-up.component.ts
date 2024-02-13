import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, ValidatorFn, Validators } from '@angular/forms';

@Component({
  selector: 'app-sign-up',
  templateUrl: './sign-up.component.html',
  styleUrls: ['./sign-up.component.css']
})
export class SignUpComponent implements OnInit{
  
  registerForm : FormGroup = new FormGroup({});

  constructor(private fb : FormBuilder) {
    
  }
  
  ngOnInit(): void {
    this.initializeForm();
  }

  initializeForm() {
    this.registerForm = this.fb.group({
      firstName : ['', Validators.required],
      lastName : ['', Validators.required],
      username : ['', Validators.required],
      dateOfBirth : ['', Validators.required],
      email : ['', [Validators.required, Validators.email]],
      password : ['', [Validators.required, Validators.minLength(4), Validators.maxLength(8)]],
      confirmPassword : ['', [Validators.required, this.matchValues('password')]]
    })

    this.registerForm.controls['password'].valueChanges.subscribe({
      next: () => this.registerForm.controls['confirmPassword'].updateValueAndValidity()
    })
  }

  matchValues(matchTo : string) : ValidatorFn {
    return (control : AbstractControl) => {
      return control.value === control.parent?.get(matchTo)?.value ? null : {notMatching : true};
    }
  }

  register(){
    console.log(this.registerForm);
    
  }

}

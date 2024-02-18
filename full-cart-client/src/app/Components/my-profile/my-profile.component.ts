import { Component, HostListener, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { take } from 'rxjs';
import { Customer } from 'src/app/Models/customer';
import { User } from 'src/app/Models/user';
import { AccountServiceService } from 'src/app/Services/account-service.service';
import { CustomerService } from 'src/app/Services/customer.service';

@Component({
  selector: 'app-my-profile',
  templateUrl: './my-profile.component.html',
  styleUrls: ['./my-profile.component.css']
})
export class MyProfileComponent implements OnInit {
  @ViewChild('editForm') editForm: NgForm | undefined;

  @HostListener('window.beforeunload', ['$event']) unloadnotification($event: any) {
    if (this.editForm?.dirty) {
      $event.returnValue = true;
    }
  }

  customer: Customer = {} as Customer; // Initialize customer with an empty object

  user: User | null = null;

  constructor(private accountService: AccountServiceService, private customerService: CustomerService) {
    this.accountService.currentUser$.pipe(take(1)).subscribe({
      next: resp => this.user = resp
    });
  }

  ngOnInit(): void {
    this.getCustomer();
  }

  getCustomer() {
    if (!this.user) return;
    this.customerService.getCustomer(this.user?.username).subscribe({
      next: resp => {
        this.customer = resp;
        console.log(this.customer.email); // Log the email after retrieving customer data
      }
    });
  }

  updateCustomer() {
    if (!this.customer) return;
    this.customerService.updateCustomer(this.customer).subscribe({
      next: _ => {
        alert("Update Successful");
        this.editForm?.reset(this.customer);
      }
    });
  }
}

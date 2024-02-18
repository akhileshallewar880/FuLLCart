import { Component, Input, OnInit } from '@angular/core';
import { Route, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Product } from 'src/app/Models/product';
import { AccountServiceService } from 'src/app/Services/account-service.service';
import { ProductsService } from 'src/app/Services/products.service';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent implements OnInit{
  
  @Input()  product : Product | undefined

  currentUserId = 0;

  constructor(private productService : ProductsService, private toastr : ToastrService,
    private accountService : AccountServiceService, private router : Router) { }

  ngOnInit(): void {
    this.getUserId();
  }

  getUserId(){
    this.accountService.currentUser$.subscribe({
      next: (user) => {
        this.currentUserId = Number(user?.id);
      }
    });
  }
  

  addToCart(productId:number){
    console.log(this.currentUserId);
    
    this.productService.addToCart(this.currentUserId,productId,1).subscribe({
      next:(response)=>{
         this.toastr.success("Added To Cart")
         this.router.navigateByUrl("user/cart");
       },
       error: (err)=>{
          console.log(err);
          
       }
    });
  }

}

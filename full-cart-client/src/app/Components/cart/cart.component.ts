import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { Observable } from 'rxjs';
import { Pagination } from 'src/app/Models/pagination';
import { Product } from 'src/app/Models/product';
import { ShoppingCart } from 'src/app/Models/shopping-cart';
import { AccountServiceService } from 'src/app/Services/account-service.service';
import { CartService } from 'src/app/Services/cart.service';
import { ProductsService } from 'src/app/Services/products.service';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})
export class CartComponent implements OnInit{

  shoppingCart : ShoppingCart | undefined;

  userId = 0;

    
  constructor(private productService : ProductsService, private toastr : ToastrService,
    private accountService : AccountServiceService) {
    
  }
  
  ngOnInit(): void {
    this.loadShoppingCart();
  }

  loadShoppingCart(){
    
    this.accountService.currentUser$.subscribe({
      next : resp => {
        this.userId = Number(resp?.id);
      }
    })
    
    this.productService.getShoppingCart(this.userId).subscribe({
      next : response => {
        this.shoppingCart = response;
      }
    })
  }

  deleteItem(cartItemId : number) {
    this.productService.removeFromCart(this.userId,cartItemId).subscribe({
      next : () => {
        this.toastr.info("The item has removed from the cart");
        this.loadShoppingCart();
      }
    })
  }

  calculateTotalPrice(): number {
    let totalPrice = 0;
    if (this.shoppingCart) {
        for (const item of this.shoppingCart.cartItems) {
            totalPrice += item.productPrice * item.quantity;
        }
    }
    return totalPrice;
}

placeOrder(){
  var model = {
      shippingAddress: "India",
      totalPrice: this.calculateTotalPrice(),
      productId: 3,
      quantity: 4,
      unitPrice: 1
    }
  }
}


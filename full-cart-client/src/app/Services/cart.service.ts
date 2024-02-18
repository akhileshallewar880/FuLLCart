import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable, tap } from 'rxjs';
import { environment } from 'src/environments/environment.development';
import { ShoppingCart } from '../Models/shopping-cart';

@Injectable({
  providedIn: 'root'
})
export class CartService {

  private baseUrl = environment.appUrl;
  private shoppingCartSubject: BehaviorSubject<ShoppingCart | null> = new BehaviorSubject<ShoppingCart | null>(null);
  public shoppingCart$: Observable<ShoppingCart | null> = this.shoppingCartSubject.asObservable();

  constructor(private http: HttpClient) { }

  addToCart(cartItem: any): Observable<any> {
    return this.http.post<any>(this.baseUrl + 'shoppingcart/', cartItem);
  }

 

  getShoppingCart(id: number): Observable<ShoppingCart> {
    return this.http.get<ShoppingCart>(this.baseUrl + 'shoppingcart/cartItems/' + id).pipe(
      tap((shoppingCart: ShoppingCart) => {
        this.shoppingCartSubject.next(shoppingCart);
      })
    );
  }
}

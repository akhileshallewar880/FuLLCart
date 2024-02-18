import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment.development';
import { Product } from '../Models/product';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable, map, of } from 'rxjs';
import { Category } from '../Models/category';
import { PaginationResult } from '../Models/pagination';
import { ShoppingCart } from '../Models/shopping-cart';
import { DeleteItem } from '../Models/delete-item';

@Injectable({
  providedIn: 'root'
})
export class ProductsService {

  baseUrl = environment.appUrl;

  products : Product[] = []

  categories : Category[] = []

  shoppingcart : ShoppingCart | undefined;

  paginatedResult : PaginationResult<Product[]> = new PaginationResult<Product[]>

  constructor(private http : HttpClient) { }

  getProducts(page?:number, itemsPerPage?:number) {
    let params = new HttpParams();

    if(page && itemsPerPage){
      params = params.append('pageNumber', page);
      params = params.append('pageSize', itemsPerPage);
    }

    return this.http.get<Product[]>(this.baseUrl + 'products', {observe: 'response', params}).pipe(
      map( res => {
        if(res.body) {
          this.paginatedResult.result = res.body;
        } 

        const pagination = res.headers.get('Pagination');
        
        if(pagination) {
          this.paginatedResult.pagination = JSON.parse(pagination);
        }

        return this.paginatedResult;
      }
    )
    )
  }

  removeFromCart(customerId:number, cartItemId : number): Observable<any> {
    const url = `${this.baseUrl}shoppingcart/removeFromCart?customerId=${customerId}&cartItemId=${cartItemId}`;
    return this.http.delete<any>(url);
  }

  getProductsByCategory(categoryId : number, page?:number, itemsPerPage?:number)
  {
    let params = new HttpParams();

    if(page && itemsPerPage){
      params = params.append('pageNumber', page)
      params = params.append('pageSize', itemsPerPage);
    }

    return this.http.get<Product[]>(this.baseUrl + 'products/category/' + categoryId, {observe: 'response', params}).pipe(
      map( res => {
        if(res.body) {
          this.paginatedResult.result = res.body;
        }

        const pagination = res.headers.get('Pagination');

        if(pagination){
          this.paginatedResult.pagination = JSON.parse(pagination);
        }

        return this.paginatedResult;
      })
    )
  }

  getProduct(productId : number) {
    const product = this.products.find(p => p.productId == productId);
    if(product) return of(product);
    
    return this.http.get<Product>(this.baseUrl + 'products/' + productId);
  }

  getCategories() {
    if(this.categories.length > 0) return of(this.categories);
    return this.http.get<Category[]>(this.baseUrl + 'products/categories').pipe(
      map((categories) => {
        this.categories = categories;
        return categories;
      })
    )
  }

  addToCart(customerId : number, productId : number, quantity : number): Observable<any> {
    const url = `${this.baseUrl}ShoppingCart?customerId=${customerId}&productId=${productId}&quantity=${quantity}`;
    return this.http.post<any>(url, {});
  }

  getShoppingCart(id : number){
    return this.http.get<ShoppingCart>(this.baseUrl + 'shoppingcart/cartItems/' + id);
  }

}

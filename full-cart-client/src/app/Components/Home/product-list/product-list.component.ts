import { Component, OnDestroy, OnInit } from '@angular/core';
import { Observable, Subscription } from 'rxjs';
import { Category } from 'src/app/Models/category';
import { Pagination } from 'src/app/Models/pagination';
import { Product } from 'src/app/Models/product';
import { CategorySelectService } from 'src/app/Services/category-select.service';
import { ProductsService } from 'src/app/Services/products.service';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit, OnDestroy{

  
  products : Product[] | undefined;
  
  productsByCategory : Product[] | undefined;

  pagination : Pagination | undefined;
  pageNumber = 1;
  pageSize = 16;

  selectedCategorySubscription: Subscription | undefined;

  constructor(private productService : ProductsService, private categorySelectService : CategorySelectService) {
    
  }

  ngOnInit(): void {
    this.loadProducts();
    this.subscribeToCategoryChanges(); 
    this.productService.getShoppingCart(3).subscribe({
      next : response => {
        console.log(response);
        
      }
    })
  }

  ngOnDestroy(): void {
    if (this.selectedCategorySubscription) {
      this.selectedCategorySubscription.unsubscribe();
    }
  }



  loadProducts() {
    this.productService.getProducts(this.pageNumber, this.pageSize).subscribe({
      next : response => {
        if(response.result && response.pagination){
          this.products = response.result;
          this.pagination = response.pagination;
        }
      }
    })
  }

  subscribeToCategoryChanges() {
    this.selectedCategorySubscription = this.categorySelectService.getSelectedCategory().subscribe({
      next : (category) => {
        if(category){
          this.loadProductsByCategory(category.categoryId);        
        } else {
          this.loadProducts();
        }
      }
    })
  }

  loadProductsByCategory(categoryId: number) {
    this.productService.getProductsByCategory(categoryId, this.pageNumber, this.pageSize).subscribe({
      next: response => {
        if (response.result && response.pagination) {
          this.products = response.result;
          this.pagination = response.pagination;
        }
      }
    });
  }

  viewMore() {
    if(this.pageSize > 48){
      this.pageNumber++
    }
    this.pageSize = this.pageSize + 4;
    this.loadProducts();
  }

  
}

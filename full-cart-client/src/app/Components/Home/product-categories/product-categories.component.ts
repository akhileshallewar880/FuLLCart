import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { Observable } from 'rxjs';
import { Category } from 'src/app/Models/category';
import { CategorySelectService } from 'src/app/Services/category-select.service';
import { ProductsService } from 'src/app/Services/products.service';

@Component({
  selector: 'app-product-categories',
  templateUrl: './product-categories.component.html',
  styleUrls: ['./product-categories.component.css']
})
export class ProductCategoriesComponent implements OnInit{
  
  categories : Category[]| undefined;

  selectedCategory: Category | null = null;

  constructor(private productService : ProductsService, private categorySelectService : CategorySelectService) {  }
  
  ngOnInit(): void {
    
    this.productService.getCategories().subscribe({
      next : (resp) => {
        this.categories = resp

      },
      error : err => console.log(err)
      
    })
  }

  onCategorySelect(category: Category) {
    this.selectedCategory = category;
    this.categorySelectService.setSelectedCategory(category);
    console.log(this.categorySelectService.selectedCategory$);
    
  }

}

import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { Category } from '../Models/category';

@Injectable({
  providedIn: 'root'
})
export class CategorySelectService {

  private selectedCategorySubject: BehaviorSubject<Category | null> = new BehaviorSubject<Category | null>(null);
  selectedCategory$: Observable<Category | null> = this.selectedCategorySubject.asObservable();

  constructor() { }

  setSelectedCategory(category: Category) {
    this.selectedCategorySubject.next(category);
  }

  getSelectedCategory(): Observable<Category | null> {
    return this.selectedCategory$;
  }
}

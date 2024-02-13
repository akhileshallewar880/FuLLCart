import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { FooterComponent } from './Components/footer/footer.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SignUpComponent } from './Components/sign-up/sign-up.component';
import { HeaderComponent } from './Components/header/header.component';
import { LoginComponent } from './login/login.component';
import { HomeBannerComponent } from './Home/home-banner/home-banner.component';
import { ProductListComponent } from './Home/product-list/product-list.component';
import { ProductCategoriesComponent } from './Home/product-categories/product-categories.component';
import { HomePageComponent } from './Home/home-page/home-page.component';
import { ProductComponent } from './Home/product-list/product/product.component';

@NgModule({
  declarations: [
    AppComponent,
    SignUpComponent,
    HeaderComponent,
    FooterComponent,
    LoginComponent,
    HomeBannerComponent,
    ProductListComponent,
    ProductCategoriesComponent,
    HomePageComponent,
    ProductComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

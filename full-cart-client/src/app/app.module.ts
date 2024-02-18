import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { FooterComponent } from './Components/footer/footer.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SignUpComponent } from './Components/sign-up/sign-up.component';
import { HeaderComponent } from './Components/header/header.component';
import { BrowserAnimationsModule, provideAnimations } from '@angular/platform-browser/animations';
import { CartComponent } from './Components/cart/cart.component';
import { MyProfileComponent } from './Components/my-profile/my-profile.component';
import { ProductDetailsComponent } from './Components/product-details/product-details.component';
import { LoginComponent } from './Components/login/login.component';
import { HomeBannerComponent } from './Components/Home/home-banner/home-banner.component';
import { ProductCategoriesComponent } from './Components/Home/product-categories/product-categories.component';
import { HomePageComponent } from './Components/Home/home-page/home-page.component';
import { ProductComponent } from './Components/Home/product-list/product/product.component';
import { ProductListComponent } from './Components/Home/product-list/product-list.component';
import { JwtInterceptor } from './Interceptors/jwt.interceptor';
import { TruncatePipe } from './Pipes/truncate.pipe';
import { ToastrModule, provideToastr } from 'ngx-toastr';
import { ErrorsInterceptor } from './Interceptors/error.interceptor';
import { LoadingInterceptor } from './Interceptors/loading.interceptor';
import { NgxSpinnerModule } from 'ngx-spinner';
import { HomeComponent } from './Components/Admin/home/home.component';

@NgModule({
  declarations: [
    AppComponent,
    SignUpComponent,
    HeaderComponent,
    FooterComponent,
    LoginComponent,
    HomeBannerComponent,
    ProductDetailsComponent,
    ProductListComponent,
    ProductCategoriesComponent,
    HomePageComponent,
    ProductComponent,
    CartComponent,
    MyProfileComponent,
    ProductDetailsComponent,
    TruncatePipe,
    HomeComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    FormsModule,
    HttpClientModule,
    BrowserAnimationsModule,
    NgxSpinnerModule,
    ToastrModule.forRoot({
      timeOut: 500,
      positionClass: 'toast-top-left',
      preventDuplicates: true,
    }),
    NgxSpinnerModule.forRoot({ type: 'line-spin-clockwise-fade' })
  ],
  providers: [
    {provide : HTTP_INTERCEPTORS, useClass : ErrorsInterceptor, multi : true },
    {provide : HTTP_INTERCEPTORS, useClass : JwtInterceptor, multi : true },
    {provide : HTTP_INTERCEPTORS, useClass : LoadingInterceptor, multi : true },
    provideAnimations(), // required animations providers
    provideToastr(), // Toastr providers
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }

import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomePageComponent } from './Home/home-page/home-page.component';
import { SignUpComponent } from './Components/sign-up/sign-up.component';
import { LoginComponent } from './login/login.component';
import { CartComponent } from './Components/cart/cart.component';
import { MyProfileComponent } from './Components/my-profile/my-profile.component';
import { ProductDetailsComponent } from './Components/product-details/product-details.component';

const routes: Routes = [
  { path: '', component: HomePageComponent },
  { path: 'signup', component : SignUpComponent},
  { path: 'cart', component : CartComponent},
  { path: 'myprofile', component : MyProfileComponent},
  { path: 'details', component : ProductDetailsComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

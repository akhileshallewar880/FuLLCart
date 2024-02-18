import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SignUpComponent } from './Components/sign-up/sign-up.component';
import { CartComponent } from './Components/cart/cart.component';
import { MyProfileComponent } from './Components/my-profile/my-profile.component';
import { ProductDetailsComponent } from './Components/product-details/product-details.component';
import { HomePageComponent } from './Components/Home/home-page/home-page.component';
import { LoginComponent } from './Components/login/login.component';
import { authGuard } from './Gaurds/auth.guard';
import { preventUnsavedChangesGuard } from './Gaurds/prevent-unsaved-changes.guard';

const routes: Routes = [
  { path: '', component: HomePageComponent },
  { path : '',
  runGuardsAndResolvers : 'always',
  canActivate : [authGuard],
  children : [
  { path: 'user/cart', component : CartComponent},
  { path: 'user/cart', component : CartComponent},
  { path: 'user/myprofile', component : MyProfileComponent, canDeactivate : [preventUnsavedChangesGuard]},
  { path: 'product/details', component : ProductDetailsComponent}
  ]
},
{ path: 'login', component : LoginComponent},
{ path: 'register', component : SignUpComponent},
  {path : '**', component : HomePageComponent, pathMatch : 'full'}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

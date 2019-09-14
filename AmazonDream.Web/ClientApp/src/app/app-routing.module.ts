import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomePageComponent } from './Common/home-page/home-page.component';
import { SellerRegistrationComponent } from './seller-home/seller-registration/seller-registration.component';
import { SellerHomeComponent } from './seller-home/seller-home.component';
import { AddProductSellerComponent } from './seller-home/add-product-seller/add-product-seller.component';
import { CustomerRegistrationComponent } from './Customer/customer-registration/customer-registration.component';
import { LoginComponent } from './Common/login/login.component';
import { ViewAllProductComponent } from './seller-home/view-all-product/view-all-product.component';
import { ViewPendingProductComponent } from './seller-home/view-pending-product/view-pending-product.component';


const routes: Routes = [
  { path: '', redirectTo: '/HomePage', pathMatch: 'full' },
  { path: 'HomePage', component: HomePageComponent },
  { path: 'HomePage/Login', component: LoginComponent },
  { path: 'HomePage/CustomerRegistration', component: CustomerRegistrationComponent },
  { path: 'HomePage/SellerRegistration', component: SellerRegistrationComponent },
  {
    path: 'SellerHome', component: SellerHomeComponent,
    children: [
      { path: 'AddProduct', component: AddProductSellerComponent },
      { path: 'ViewProduct', component: ViewAllProductComponent },
      { path: 'PendingProduct', component: ViewPendingProductComponent }

    ]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

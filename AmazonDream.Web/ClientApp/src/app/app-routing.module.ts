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
import { ViewTrendingProductComponent } from './seller-home/view-trending-product/view-trending-product.component';
import { ViewTrendRequestedProductComponent } from './seller-home/view-trend-requested-product/view-trend-requested-product.component';
import { AddProductPictureComponent } from './seller-home/add-product-picture/add-product-picture.component';


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
      { path: 'PendingProduct', component: ViewPendingProductComponent },
      { path: 'TrendingProduct', component: ViewTrendingProductComponent },
      { path: 'TrendRequestedProduct', component: ViewTrendRequestedProductComponent },
      { path: 'AddProductPicture', component: AddProductPictureComponent }



    ]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

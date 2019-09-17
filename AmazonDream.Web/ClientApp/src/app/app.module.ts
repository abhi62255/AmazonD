import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomePageComponent } from './Common/home-page/home-page.component';
import { SellerRegistrationComponent } from './seller-home/seller-registration/seller-registration.component';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { SellerHomeComponent } from './seller-home/seller-home.component';
import { AdminHomeComponent } from './admin-home/admin-home.component';
import { LoginComponent } from './Common/login/login.component';
import { CustomerRegistrationComponent } from './Customer/customer-registration/customer-registration.component';
import { AddProductSellerComponent } from './seller-home/add-product-seller/add-product-seller.component';
import { ConstantsService } from './Services/constants.service';
import { ProductService } from './Services/product.service';
import { LoginService } from './Services/login.service';
import { CustomerRegistrationService } from './Services/customer-registration.service';
import { SellerRegistrationService } from './Services/seller-registration.service';
import { ViewAllProductComponent } from './seller-home/view-all-product/view-all-product.component';
import { ViewPendingProductComponent } from './seller-home/view-pending-product/view-pending-product.component';
import { ViewTrendingProductComponent } from './seller-home/view-trending-product/view-trending-product.component';
import { ViewTrendRequestedProductComponent } from './seller-home/view-trend-requested-product/view-trend-requested-product.component';
import { AddProductPictureComponent } from './seller-home/add-product-picture/add-product-picture.component';
import { EditProductValuesComponent } from './seller-home/view-all-product/edit-product-values/edit-product-values.component';
import { ReceivedOrderComponent } from './seller-home/received-order/received-order.component';
import { SellerRequestsComponent } from './admin-home/seller-requests/seller-requests.component';
import { ViewProductComponent } from './admin-home/view-product/view-product.component';
import { PendingProductComponent } from './admin-home/pending-product/pending-product.component';
import { ViewSellerComponent } from './admin-home/view-seller/view-seller.component';
import { TrendingProductComponent } from './admin-home/trending-product/trending-product.component';
import { TrendRequestComponent } from './admin-home/trend-request/trend-request.component';
import { OrdersComponent } from './admin-home/orders/orders.component';

@NgModule({
  declarations: [
    AppComponent,
    HomePageComponent,
    LoginComponent,
    CustomerRegistrationComponent,
    SellerRegistrationComponent,
    SellerHomeComponent,
    AdminHomeComponent,
    AddProductSellerComponent,
    ViewAllProductComponent,
    ViewPendingProductComponent,
    ViewTrendingProductComponent,
    ViewTrendRequestedProductComponent,
    AddProductPictureComponent,
    EditProductValuesComponent,
    ReceivedOrderComponent,
    SellerRequestsComponent,
    ViewProductComponent,
    PendingProductComponent,
    ViewSellerComponent,
    TrendingProductComponent,
    TrendRequestComponent,
    OrdersComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [ConstantsService,
    ProductService,
    LoginService,
    CustomerRegistrationService,
    SellerRegistrationService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }

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
import { EditProductValuesComponent } from './seller-home/view-all-product/edit-product-values/edit-product-values.component';
import { ReceivedOrderComponent } from './seller-home/received-order/received-order.component';
import { AdminHomeComponent } from './admin-home/admin-home.component';
import { SellerRequestsComponent } from './admin-home/seller-requests/seller-requests.component';
import { ViewSellerComponent } from './admin-home/view-seller/view-seller.component';
import { ViewProductComponent } from './admin-home/view-product/view-product.component';
import { PendingProductComponent } from './admin-home/pending-product/pending-product.component';
import { TrendingProductComponent } from './admin-home/trending-product/trending-product.component';
import { TrendRequestComponent } from './admin-home/trend-request/trend-request.component';
import { OrdersComponent } from './admin-home/orders/orders.component';
import { ProductHomeComponent } from './Common/product-home/product-home.component';
import { ProductsComponent } from './Common/products/products.component';
import { LogoutComponent } from './Common/logout/logout.component';
import { KartComponent } from './Common/kart/kart.component';
import { AddressComponent } from './Common/address/address.component';
import { AddAddressComponent } from './Common/address/add-address/add-address.component';
import { PaymentModeComponent } from './Common/payment-mode/payment-mode.component';
import { VerifyOrderComponent } from './Common/verify-order/verify-order.component';
import { WishComponent } from './Common/wish/wish.component';
import { PrevisitComponent } from './Common/previsit/previsit.component';
import { ReviewsComponent } from './Common/reviews/reviews.component';
import { SimilarProductsComponent } from './Common/similar-products/similar-products.component';
import { RefreshComponentComponent } from './Common/refresh-component/refresh-component.component';
import { OrderHistoryComponent } from './Common/order-history/order-history.component';


const routes: Routes = [
  { path: '', redirectTo: '/HomePage/Product', pathMatch: 'full' },
  { path: 'Homepage', redirectTo: '/HomePage/Product', pathMatch: 'full' },
  {
    path: 'HomePage', component: HomePageComponent,
    children: [
      { path: 'Product', component: ProductsComponent },
      {
        path: 'ProductHome', component: ProductHomeComponent,
        children: [
          { path: 'Reviews', component: ReviewsComponent },
          { path: 'SimilarProducts', component: SimilarProductsComponent }
        ]
      },
      { path: 'Logout', component: LogoutComponent },
      {
        path: 'Kart', component: KartComponent,
        children: [
          {
            path: 'Address', component: AddressComponent,
            children: [
              { path: 'AddAddress', component: AddAddressComponent }
            ]
          },
          { path: 'PaymentMode', component: PaymentModeComponent },
          { path: 'VerifyOrder', component: VerifyOrderComponent }

        ]
      },
      { path: 'Wish', component: WishComponent },
      { path: 'Previsit', component: PrevisitComponent },
      { path: 'OrderHistory', component: OrderHistoryComponent }



    ]
  },
  { path: 'HomePage/Login', component: LoginComponent },
  { path: 'HomePage/CustomerRegistration', component: CustomerRegistrationComponent },
  { path: 'HomePage/SellerRegistration', component: SellerRegistrationComponent },
  { path: 'HomePage/RefreshComponent', component: RefreshComponentComponent },




  {
    path: 'SellerHome', component: SellerHomeComponent,
    children: [
      { path: 'AddProduct', component: AddProductSellerComponent },
      { path: 'ViewProduct', component: ViewAllProductComponent },
      { path: 'PendingProduct', component: ViewPendingProductComponent },
      { path: 'TrendingProduct', component: ViewTrendingProductComponent },
      { path: 'TrendRequestedProduct', component: ViewTrendRequestedProductComponent },
      { path: 'AddProductPicture', component: AddProductPictureComponent },
      { path: 'ReceivedOrders', component: ReceivedOrderComponent }

    ]
  },
  { path: 'SellerHome/ViewProduct/UpdateValues', component: EditProductValuesComponent },
  {
    path: 'AdminHome', component: AdminHomeComponent,
    children: [
      { path: 'SellerRequest', component: SellerRequestsComponent },
      { path: 'ViewSeller', component: ViewSellerComponent },
      { path: 'ViewProduct', component: ViewProductComponent },
      { path: 'PendingProduct', component: PendingProductComponent },
      { path: 'TrendingProduct', component: TrendingProductComponent },
      { path: 'TrendRequest', component: TrendRequestComponent },
      { path: 'Orders', component: OrdersComponent }



    ]
  }

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

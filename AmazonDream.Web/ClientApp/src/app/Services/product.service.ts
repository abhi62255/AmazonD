import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ConstantsService } from '../Services/constants.service';
import { Observable } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class ProductService {

  constructor(private http: HttpClient, private _constant: ConstantsService) { }

  addProduct(Product: any) {
    console.log(Product);

    return this.http
      .post(this._constant.baseUrl + 'sellerproduct/product'
        , Product
      );
  }

  addProductPicture(ProductPicture: any) {          //add product picture
    console.log(ProductPicture);
    this._constant.Product_ID = 3;
    ProductPicture.Product_ID = this._constant.Product_ID;
    return this.http
      .post(this._constant.baseUrl + 'sellerproduct/productPicture'
      , ProductPicture
      );
  }

  getAcceptedProducts(): Observable<any> {
    this._constant.Seller_ID = 1;       //Need to change this later After LoginProcess is over
    return this.http.get(this._constant.baseUrl + 'SellerProduct/accepted/' + this._constant.Seller_ID);    //Give all active product of seller
  }
  getPendingProducts(): Observable<any> {
    this._constant.Seller_ID = 1;       //Need to change this later After LoginProcess is over
    return this.http.get(this._constant.baseUrl + 'SellerProduct/pending/' + this._constant.Seller_ID);    //Give all pending product of seller
  }

  getTrendingProducts(): Observable<any> {
    this._constant.Seller_ID = 1;       //Need to change this later After LoginProcess is over
    return this.http.get(this._constant.baseUrl + 'SellerProduct/trending/True/' + this._constant.Seller_ID);    //Give all Trending product of seller
  }
  getTrendRequestedProducts(): Observable<any> {
    this._constant.Seller_ID = 1;       //Need to change this later After LoginProcess is over
    return this.http.get(this._constant.baseUrl + 'SellerProduct/trending/Requested/' + this._constant.Seller_ID);    //Give all Trend request product of seller
  }
}

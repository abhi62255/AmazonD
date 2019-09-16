import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ConstantsService } from '../Services/constants.service';
import { Observable } from 'rxjs';
import { concat } from 'rxjs/operators';


@Injectable({
  providedIn: 'root'
})
export class ProductService {

  constructor(private http: HttpClient, private _constant: ConstantsService) { }

  addProduct(Product: any) {                    //add product
    console.log(Product);

    return this.http
      .post(this._constant.baseUrl + 'sellerproduct/product'
        , Product
      );
  }

  addProductPicture(ProductPicture: any) {          //add product picture
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

  deleteProduct(id: number) {
    console.log("Delete service");
    return this.http.delete(this._constant.baseUrl + 'sellerproduct/delete/' + id);    //Delete Product
  }


  trendRequest(value: string, id: number) {
    console.log("Delete service");
    return this.http.put(this._constant.baseUrl + 'sellerproduct/trendrequest/' + value + '/' + id, null);    // Trend request product for seller
  }

  updateValues(values: any) {
    values.ID = this._constant.Product_ID;
    return this.http.put(this._constant.baseUrl + 'sellerproduct/updatevalues', values);    //Update Product Values
  }
}

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
    ProductPicture.Product_ID = localStorage.getItem("Product_ID");
    ProductPicture.PicturePath = ProductPicture.PicturePath.replace('C:\\fakepath\\', '');    //Remove fake path From Picture Path
    return this.http
      .post(this._constant.baseUrl + 'sellerproduct/productPicture'
      , ProductPicture
      );
  }

  getAcceptedProducts(): Observable<any> {
    return this.http.get(this._constant.baseUrl + 'SellerProduct/accepted/' + localStorage.getItem("Seller_ID"));    //Give all active product of seller
  }
  getPendingProducts(): Observable<any> {
    return this.http.get(this._constant.baseUrl + 'SellerProduct/pending/' + localStorage.getItem("Seller_ID"));    //Give all pending product of seller
  }

  getTrendingProducts(): Observable<any> {
    return this.http.get(this._constant.baseUrl + 'SellerProduct/trending/True/' + localStorage.getItem("Seller_ID"));    //Give all Trending product of seller
  }
  getTrendRequestedProducts(): Observable<any> {
    return this.http.get(this._constant.baseUrl + 'SellerProduct/trending/Requested/' + localStorage.getItem("Seller_ID"));    //Give all Trend request product of seller
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
    values.ID = localStorage.getItem("Product_ID");
    return this.http.put(this._constant.baseUrl + 'sellerproduct/updatevalues', values);    //Update Product Values
  }

  getProduct(status: string): Observable<any>{
    return this.http.get(this._constant.baseUrl + 'AdminHome/product/' + status);    //Give all product by status
  }

  respondProductRequest(status: string, id: number) {
    return this.http.put(this._constant.baseUrl + 'AdminHome/product/' + status + '/' + id, null);    //Respond to product Request

  }

  trendProduct(status: string, id: number) {
    return this.http.put(this._constant.baseUrl + 'AdminHome/TrendResponse/' + status + '/' + id, null);    //Respond to product trend Request
  }

  getTrendingProductsAll(): Observable<any> {
    return this.http.get(this._constant.baseUrl + 'AdminHome/ProductTrend');    //Give all Trending products
  }

  getTrendRequestProductsAll(): Observable<any> {
    return this.http.get(this._constant.baseUrl + 'AdminHome/ProductTrendRequest');    //Give all Trend Request products
  }

  getProductDetails(): Observable<any> {
    return this.http.get(this._constant.baseUrl + 'product/' + localStorage.getItem("Product_ID"));    //Give one product
  }

  getProductPicture(): Observable<any> {
    return this.http.get(this._constant.baseUrl + 'product/picture/' + localStorage.getItem("Product_ID"));    //Give product pictures
  }


}

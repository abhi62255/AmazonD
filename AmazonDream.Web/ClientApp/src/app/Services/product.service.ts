import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ConstantsService } from '../Services/constants.service';
import { Observable } from 'rxjs';
import { concat } from 'rxjs/operators';


@Injectable({
  providedIn: 'root'
})
export class ProductService {

  constructor(private http: HttpClient, private _constant: ConstantsService) { }

  token = localStorage.getItem("Token");
  headers = {
    headers: new HttpHeaders().set('Authorization', "Bearer " + this.token)
  };

  addProduct(Product: any) {                    //add product
    console.log(Product);

    return this.http
      .post(this._constant.baseUrl + 'sellerproduct/product'
      , Product, { headers: this.headers.headers }
      );
  }

  addProductPicture(ProductPicture: any) {          //add product picture
    ProductPicture.Product_ID = localStorage.getItem("Product_ID");
    ProductPicture.PicturePath = ProductPicture.PicturePath.replace('C:\\fakepath\\', '');    //Remove fake path From Picture Path
    return this.http
      .post(this._constant.baseUrl + 'sellerproduct/productPicture'
      , ProductPicture, { headers: this.headers.headers }
      );
  }

  getAcceptedProducts(): Observable<any> {
    return this.http.get(this._constant.baseUrl + 'SellerProduct/accepted/' + localStorage.getItem("Seller_ID"), { headers: this.headers.headers });    //Give all active product of seller
  }
  getPendingProducts(): Observable<any> {
    return this.http.get(this._constant.baseUrl + 'SellerProduct/pending/' + localStorage.getItem("Seller_ID"), { headers: this.headers.headers });    //Give all pending product of seller
  }

  getTrendingProducts(): Observable<any> {
    return this.http.get(this._constant.baseUrl + 'SellerProduct/trending/True/' + localStorage.getItem("Seller_ID"), { headers: this.headers.headers });    //Give all Trending product of seller
  }
  getTrendRequestedProducts(): Observable<any> {
    return this.http.get(this._constant.baseUrl + 'SellerProduct/trending/Requested/' + localStorage.getItem("Seller_ID"), { headers: this.headers.headers });    //Give all Trend request product of seller
  }

  deleteProduct(id: number) {
    console.log("Delete service");
    return this.http.delete(this._constant.baseUrl + 'sellerproduct/delete/' + id, { headers: this.headers.headers });    //Delete Product
  }


  trendRequest(value: string, id: number) {
    console.log("Delete service");
    return this.http.put(this._constant.baseUrl + 'sellerproduct/trendrequest/' + value + '/' + id, null, { headers: this.headers.headers });    // Trend request product for seller
  }

  updateValues(values: any) {
    values.ID = localStorage.getItem("Product_ID");
    return this.http.put(this._constant.baseUrl + 'sellerproduct/updatevalues', values, { headers: this.headers.headers });    //Update Product Values
  }

  getProduct(status: string): Observable<any>{
    return this.http.get(this._constant.baseUrl + 'AdminHome/product/' + status, { headers: this.headers.headers });    //Give all product by status
  }

  respondProductRequest(status: string, id: number) {
    return this.http.put(this._constant.baseUrl + 'AdminHome/product/' + status + '/' + id, null, { headers: this.headers.headers });    //Respond to product Request

  }

  trendProduct(status: string, id: number) {
    return this.http.put(this._constant.baseUrl + 'AdminHome/TrendResponse/' + status + '/' + id, null, { headers: this.headers.headers });    //Respond to product trend Request
  }

  getTrendingProductsAll(): Observable<any> {
    return this.http.get(this._constant.baseUrl + 'AdminHome/ProductTrend', { headers: this.headers.headers });    //Give all Trending products
  }

  getTrendRequestProductsAll(): Observable<any> {
    return this.http.get(this._constant.baseUrl + 'AdminHome/ProductTrendRequest', { headers: this.headers.headers });    //Give all Trend Request products
  }

  getProductDetails(): Observable<any> {
    return this.http.get(this._constant.baseUrl + 'product/' + localStorage.getItem("Product_ID"));    //Give one product
  }

  getProductPicture(): Observable<any> {
    return this.http.get(this._constant.baseUrl + 'product/picture/' + localStorage.getItem("Product_ID"));    //Give product pictures
  }

 

}

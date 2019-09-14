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

  getAcceptedProducts(): Observable<any> {
    this._constant.Seller_ID = 1;       //Need to change this later After LoginProcess is over
    return this.http.get(this._constant.baseUrl + 'SellerProduct/accepted/' + this._constant.Seller_ID);    //Give all active product of seller
  }
  getPendingProducts(): Observable<any> {
    this._constant.Seller_ID = 1;       //Need to change this later After LoginProcess is over
    return this.http.get(this._constant.baseUrl + 'SellerProduct/pending/' + this._constant.Seller_ID);    //Give all active product of seller
  }
}

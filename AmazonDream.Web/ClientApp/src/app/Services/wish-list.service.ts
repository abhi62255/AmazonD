import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ConstantsService } from './constants.service';
import { Observable } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class WishListService {

  constructor(private http: HttpClient, private _constant: ConstantsService) { }
  token = localStorage.getItem("Token");
  headers = {
    headers: new HttpHeaders().set('Authorization', "Bearer " + this.token)
  };

  addWish(wish: any) {
    return this.http.post(this._constant.baseUrl + 'Wishlist', wish, { headers: this.headers.headers });    //add to wish list
  }

  getWishlist(): Observable<any> {
    return this.http.get(this._constant.baseUrl + 'Wishlist/customer/' + localStorage.getItem("Customer_ID"), { headers: this.headers.headers });    //Give wishlist of customer
  }

  removeWish(id: number) {
    return this.http.delete(this._constant.baseUrl + 'Wishlist/item/' + id, { headers: this.headers.headers });    //remove wish from wish list

  }
}

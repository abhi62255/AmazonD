import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ConstantsService } from './constants.service';
import { Observable } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class WishListService {

  constructor(private http: HttpClient, private _constant: ConstantsService) { }


  addWish(wish: any) {
    return this.http.post(this._constant.baseUrl + 'Wishlist', wish);    //Respond to sellerRequest
  }

  getWishlist(): Observable<any> {
    return this.http.get(this._constant.baseUrl + 'Wishlist/customer/' + localStorage.getItem("Customer_ID"));    //Give wishlist of customer
  }

  removeWish(id: number) {
    return this.http.delete(this._constant.baseUrl + 'Wishlist/item/' + id);    //remove wish from wish list

  }
}

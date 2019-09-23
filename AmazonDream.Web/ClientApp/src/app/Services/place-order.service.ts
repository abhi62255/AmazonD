import { Injectable } from '@angular/core';
import { ConstantsService } from './constants.service';
import { HttpClient, HttpHeaders } from '@angular/common/http';


@Injectable({
  providedIn: 'root'
})
export class PlaceOrderService {

  constructor(private http: HttpClient, private _constant: ConstantsService) { }

  token = localStorage.getItem("Token");
  headers = {
    headers: new HttpHeaders().set('Authorization', "Bearer " + this.token)
  };

  placeOrder(placeOrder: any) {
    return this.http.post(this._constant.baseUrl + 'PlaceOrder/add', placeOrder, { headers: this.headers.headers });
  }


}

import { Injectable } from '@angular/core';
import { ConstantsService } from './constants.service';
import { HttpClient } from '@angular/common/http';


@Injectable({
  providedIn: 'root'
})
export class PlaceOrderService {

  constructor(private http: HttpClient, private _constant: ConstantsService) { }

  placeOrder(placeOrder: any) {
    return this.http.post(this._constant.baseUrl + 'PlaceOrder/add', placeOrder);
  }


}

import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ConstantsService } from '../Services/constants.service';
import { Observable } from 'rxjs';
import { concat } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class OrderPlacedService {

  constructor(private http: HttpClient, private _constant: ConstantsService) { }


  receivedOrder(): Observable<any>  {
    this._constant.Seller_ID = 1;       //Need to change this later After LoginProcess is over
    return this.http.get(this._constant.baseUrl + 'sellerhome/placedorder/' + this._constant.Seller_ID);    //Give all active product of seller

  }

  updateStatus(Status: string, id: number) {

    return this.http.post(this._constant.baseUrl + 'sellerhome/updateStatus/' + Status + '/' + id, null);    //Give all active product of seller

  }


  placedOrderAdmin(): Observable<any> {
    return this.http.get(this._constant.baseUrl + 'AdminHome/PlacedOrder');    //Give all placed order all (for admin)

  }





}

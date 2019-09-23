import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ConstantsService } from '../Services/constants.service';
import { Observable } from 'rxjs';
import { concat } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class OrderPlacedService {

  constructor(private http: HttpClient, private _constant: ConstantsService) { }


  token = localStorage.getItem("Token");
  headers = {
    headers: new HttpHeaders().set('Authorization', "Bearer " + this.token)
  };

  receivedOrder(): Observable<any>  {
    return this.http.get(this._constant.baseUrl + 'sellerhome/placedorder/' + localStorage.getItem("Seller_ID"), { headers: this.headers.headers });    //Give all active product of seller

  }

  updateStatus(Status: string, id: number) {

    return this.http.post(this._constant.baseUrl + 'sellerhome/updateStatus/' + Status + '/' + id, null, { headers: this.headers.headers });    //Give all active product of seller

  }


  placedOrderAdmin(): Observable<any> {
    return this.http.get(this._constant.baseUrl + 'AdminHome/PlacedOrder', { headers: this.headers.headers });    //Give all placed order all (for admin)

  }

  placedOrderCustomer(): Observable<any> {
    return this.http.get(this._constant.baseUrl + 'PlaceOrder/' + localStorage.getItem("Customer_ID"), { headers: this.headers.headers });    //Give all placed order all (for admin)

  }





}

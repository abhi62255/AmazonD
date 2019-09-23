import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ConstantsService } from './constants.service';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SellerServiceService {

  constructor(private http: HttpClient, private _constant: ConstantsService) { }

  token = localStorage.getItem("Token");
  headers = {
    headers: new HttpHeaders().set('Authorization', "Bearer " + this.token)
  };

  getSeller(status: string): Observable<any> {
    return this.http.get(this._constant.baseUrl + 'AdminHome/Seller/' + status, { headers: this.headers.headers });    //Give all Seller
  }
  getSellerAddress(id: number): Observable<any> {
    return this.http.get(this._constant.baseUrl + 'Address/seller/' + id, { headers: this.headers.headers });    //Give Seller address
  }

  respondSellerRequest(status: string, id: number) {
    return this.http.put(this._constant.baseUrl + 'AdminHome/Seller/' + status + '/' + id, null, { headers: this.headers.headers });    //Respond to sellerRequest
  }


}

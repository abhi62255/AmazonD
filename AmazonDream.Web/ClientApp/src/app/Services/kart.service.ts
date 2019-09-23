import { Injectable } from '@angular/core';
import { ConstantsService } from './constants.service';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Kart } from '../Model/Kart';
import { Observable } from 'rxjs';


@Injectable({
  providedIn: 'root'
})


export class KartService {

  constructor(private http: HttpClient, private _constant: ConstantsService) { }
  kartmodel = new Kart();
  token = localStorage.getItem("Token");
  headers = {
    headers: new HttpHeaders().set('Authorization', "Bearer " + this.token)
  };

  addProductToKart(id: number) {
    this.kartmodel.Quantity = 1;
    this.kartmodel.Product_ID = id;
    this.kartmodel.Customer_ID = <number><any>localStorage.getItem("Customer_ID");
    return this.http
      .post(this._constant.baseUrl + 'CustomerKart/add'
      , this.kartmodel, { headers: this.headers.headers }
      );
  }

  getKartByCustomerId(): Observable<any>
  {    
    return this.http.get(this._constant.baseUrl + 'CustomerKart/' + localStorage.getItem("Customer_ID"), { headers: this.headers.headers});    //Give Kart values for seller
  }

  updateKartQuantity(action: string, id: number) {
    return this.http.put(this._constant.baseUrl + 'CustomerKart/' + action + '/' + id, null, { headers: this.headers.headers });    //Update Kart Quantity
  }

  removeItemFromKart(id: number) {
    return this.http.put(this._constant.baseUrl + 'CustomerKart/RemoveItem/' + id, null, { headers: this.headers.headers });    //Update Kart Quantity
  }

  clearKart() {
    return this.http.put(this._constant.baseUrl + 'CustomerKart/Remove/' + localStorage.getItem("Customer_ID"), null, { headers: this.headers.headers });    //Update Kart Quantity
  }

}

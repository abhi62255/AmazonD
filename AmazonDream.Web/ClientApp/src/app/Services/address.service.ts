import { Injectable } from '@angular/core';
import { ConstantsService } from './constants.service';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class AddressService {

  constructor(private http: HttpClient, private _constant: ConstantsService) { }

  token = localStorage.getItem("Token");
  headers = {
    headers: new HttpHeaders().set('Authorization', "Bearer " + this.token)
  };

  customerAddress(): Observable<any> {
    return this.http.get(this._constant.baseUrl + 'Address/customer/' + localStorage.getItem("Customer_ID"), { headers: this.headers.headers });    //Give CustomerAddress
  }

  deleteAddress(id: number) {
    return this.http.delete(this._constant.baseUrl + 'Address/delete/' + id, { headers: this.headers.headers });    //Delete address
  }

  addAddress(address: any) {
    console.log(address);

    address.Customer_ID = localStorage.getItem("Customer_ID");
    address.Seller_ID = localStorage.getItem("Seller_ID");
    console.log(address);

    return this.http.post(this._constant.baseUrl + 'address/add', address, { headers: this.headers.headers });
  }

  getAddress(): Observable<any> {
    return this.http.get(this._constant.baseUrl + 'Address/' + localStorage.getItem("Address_ID"), { headers: this.headers.headers });    //Give Address by ID
  }
}

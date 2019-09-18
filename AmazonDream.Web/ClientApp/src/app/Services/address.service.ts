import { Injectable } from '@angular/core';
import { ConstantsService } from './constants.service';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class AddressService {

  constructor(private http: HttpClient, private _constant: ConstantsService) { }

  customerAddress(): Observable<any> {
    return this.http.get(this._constant.baseUrl + 'Address/customer/' + localStorage.getItem("Customer_ID"));    //Give CustomerAddress
  }

  deleteAddress(id: number) {
    return this.http.delete(this._constant.baseUrl + 'Address/delete/' + id);    //Delete address
  }

  addAddress(address: any) {
    console.log(address);

    address.Customer_ID = localStorage.getItem("Customer_ID");
    address.Seller_ID = localStorage.getItem("Seller_ID");
    console.log(address);

    return this.http.post(this._constant.baseUrl + 'address/add', address );
  }

  getAddress(): Observable<any> {
    return this.http.get(this._constant.baseUrl + 'Address/' + localStorage.getItem("Address_ID"));    //Give Address by ID
  }
}

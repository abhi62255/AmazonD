import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ConstantsService } from './constants.service';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ProductSuggestionsService {

  constructor(private http: HttpClient, private _constant: ConstantsService) { }

  token = localStorage.getItem("Token");
  headers = {
    headers: new HttpHeaders().set('Authorization', "Bearer " + this.token)
  };


  GetSuggestedProductsKnownUser(): Observable<any> {
    console.log("Known user");
    return this.http.get(this._constant.baseUrl + 'ProductSuggestions/' + localStorage.getItem("Customer_ID"), { headers: this.headers.headers });    //give product suggestion for customer
  }

  GetSuggestedProductsUnknownUser(): Observable<any> {
    console.log("UNKnown user");
    return this.http.get(this._constant.baseUrl + 'ProductSuggestions');   //give product suggestion for Unknown customer(Only trending products)
  }

  GetSuggestedProductsAll(): Observable<any> {
    console.log("all user");
    return this.http.get(this._constant.baseUrl + 'ProductSuggestions/all');   //give product suggestion for all customer
  }
}

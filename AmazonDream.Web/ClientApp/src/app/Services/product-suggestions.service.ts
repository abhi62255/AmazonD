import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ConstantsService } from './constants.service';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ProductSuggestionsService {

  constructor(private http: HttpClient, private _constant: ConstantsService) { }



  GetSuggestedProductsKnownUser(): Observable<any> {
    console.log("Known user");
    this._constant.Customer_ID = 1;       //Need to change this later After LoginProcess is over
    return this.http.get(this._constant.baseUrl + 'ProductSuggestions/' + this._constant.Customer_ID);    //give product suggestion for customer
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

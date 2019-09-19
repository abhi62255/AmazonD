import { Injectable } from '@angular/core';
import { ConstantsService } from './constants.service';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SimilarProductsService {

  constructor(private http: HttpClient, private _constant: ConstantsService) { }


  getSimilarProducts(): Observable<any> {
    return this.http.get(this._constant.baseUrl + 'ProductSuggestions/similar/' + localStorage.getItem("Product_ID"));    //Get product reviews
  }
}

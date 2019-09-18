import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ConstantsService } from './constants.service';


@Injectable({
  providedIn: 'root'
})
export class PrevisitService {

  constructor(private http: HttpClient, private _constant: ConstantsService) { }

  addPrevisit() {
    console.log("Previsitsddddddddddddd");
    return this.http.post(this._constant.baseUrl + 'previsit/' + localStorage.getItem("Customer_ID") + '/' + localStorage.getItem("Product_ID"), null);    //add previsit
  }
}

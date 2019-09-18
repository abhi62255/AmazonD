import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ConstantsService } from './constants.service';
import { Observable } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class PrevisitService {

  constructor(private http: HttpClient, private _constant: ConstantsService) { }

  addPrevisit() {
    console.log("Previsitsddddddddddddd");
    return this.http.post(this._constant.baseUrl + 'previsit/' + localStorage.getItem("Customer_ID") + '/' + localStorage.getItem("Product_ID"), null);    //add previsit
  }
  getPrevisit(): Observable<any> {
    return this.http.get(this._constant.baseUrl + 'previsit/' + localStorage.getItem("Customer_ID"));    //add previsit
  }
}

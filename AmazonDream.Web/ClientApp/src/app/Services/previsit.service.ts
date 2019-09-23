import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ConstantsService } from './constants.service';
import { Observable } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class PrevisitService {

  constructor(private http: HttpClient, private _constant: ConstantsService) { }

  token = localStorage.getItem("Token");
  headers = {
    headers: new HttpHeaders().set('Authorization', "Bearer " + this.token)
  };

  addPrevisit() {
    console.log("Previsitsddddddddddddd");
    return this.http.post(this._constant.baseUrl + 'previsit/' + localStorage.getItem("Customer_ID") + '/' + localStorage.getItem("Product_ID"), null, { headers: this.headers.headers });    //add previsit
  }
  getPrevisit(): Observable<any> {
    return this.http.get(this._constant.baseUrl + 'previsit/' + localStorage.getItem("Customer_ID"), { headers: this.headers.headers });    //add previsit
  }
}

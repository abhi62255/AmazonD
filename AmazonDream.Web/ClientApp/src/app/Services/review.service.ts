import { Injectable } from '@angular/core';
import { ConstantsService } from './constants.service';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class ReviewService {

  constructor(private http: HttpClient, private _constant: ConstantsService) { }

  token = localStorage.getItem("Token");
  headers = {
    headers: new HttpHeaders().set('Authorization', "Bearer " + this.token)
  };

  getReview(): Observable<any> {
    return this.http.get(this._constant.baseUrl + 'Feedback/' + localStorage.getItem("Product_ID"));    //Get product reviews
  }

  addReview(review: any) {
    return this.http.post(this._constant.baseUrl + 'Feedback', review, { headers: this.headers.headers });    //Give review to product
  }

}

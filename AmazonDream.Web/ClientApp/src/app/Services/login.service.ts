import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ConstantsService } from '../Services/constants.service';



@Injectable({
  providedIn: 'root'
})
export class LoginService {

  constructor(private http: HttpClient, private _constant: ConstantsService) { }

  login(Credentials: any) {
    console.log(Credentials);

    return this.http
      .post(this._constant.baseUrl +'Login'
      , Credentials
      );

  }
}

import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { ConstantsService } from '../Services/constants.service';


@Injectable({
  providedIn: 'root'
})
export class SellerRegistrationService {

  constructor(private http: HttpClient, private _constant: ConstantsService) { }

  addSellerDB(seller: any) {
    console.log(seller);

    return this.http
      .post(this._constant.baseUrl +'sellerhome'
        , seller
      );

  }
}

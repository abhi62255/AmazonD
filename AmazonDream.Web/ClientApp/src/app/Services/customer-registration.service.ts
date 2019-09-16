import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ConstantsService } from '../Services/constants.service';



@Injectable({
  providedIn: 'root'
})

export class CustomerRegistrationService {

  constructor(private http: HttpClient, private _constant: ConstantsService) { }

  addCustomerDB(customer: any) {
    console.log(customer);

    return this.http
      .post(this._constant.baseUrl +'customerRegistration'
        , customer
      );

  }
}

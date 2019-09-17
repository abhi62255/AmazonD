import { Injectable } from '@angular/core';
import { ConstantsService } from './constants.service';
import { HttpClient } from '@angular/common/http';
import { Kart } from '../Model/Kart';


@Injectable({
  providedIn: 'root'
})


export class KartService {

  constructor(private http: HttpClient, private _constant: ConstantsService) { }

  kartmodel= new Kart();

  addProductToKart(id: number) {
    this._constant.Customer_ID = 1;
    this.kartmodel.Quantity = 1;
    this.kartmodel.Product_ID = id;
    this.kartmodel.Customer_ID = this._constant.Customer_ID;
    return this.http
      .post(this._constant.baseUrl + 'CustomerKart/add'
      , this.kartmodel
      );
  }
}

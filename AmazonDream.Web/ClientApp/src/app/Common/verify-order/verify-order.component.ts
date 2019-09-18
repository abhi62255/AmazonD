import { Component, OnInit } from '@angular/core';
import { AddressService } from 'src/app/Services/address.service';
import { PlaceOrder } from 'src/app/Model/PlaceOrder';
import { PlaceOrderService } from 'src/app/Services/place-order.service';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';

@Component({
  selector: 'app-verify-order',
  templateUrl: './verify-order.component.html',
  styleUrls: ['./verify-order.component.css']
})
export class VerifyOrderComponent implements OnInit {

  constructor(private _address: AddressService, private _placedorder: PlaceOrderService, private toastr: ToastrService, private router: Router) { }

  PaymentMode = localStorage.getItem("PaymentMode");
  Address: any;
  placeorder = new PlaceOrder();

  getAddress() {
    this._address.getAddress()
      .subscribe((data: any) => this.Address = "Address Line : " + data.addressLine + " City : " + data.city +
        " State : " + data.state + " Postal Code : " + data.postalCode+" ");

  }


  placeOrder() {
    this.placeorder.PaymentType = localStorage.getItem("PaymentMode");
    this.placeorder.Address_ID = <number><any>localStorage.getItem("Address_ID");
    this.placeorder.Customer_ID = <number><any>localStorage.getItem("Customer_ID");
    this._placedorder.placeOrder(this.placeorder).subscribe();    

    this.toastr.success("Order Placed Successfully");
    this.router.navigate(['']);     //redirect to home page
   
  }

  ngOnInit() {
    this.getAddress();
  }

}

import { Component, OnInit } from '@angular/core';
import { AddressService } from 'src/app/Services/address.service';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';

@Component({
  selector: 'app-address',
  templateUrl: './address.component.html',
  styleUrls: ['./address.component.css']
})
export class AddressComponent implements OnInit {

  constructor(private _address: AddressService, private toastr: ToastrService, private router: Router) { }

  public addressList: any[];


  deleteAddress(id: number) {
    this._address.deleteAddress(id).subscribe(
      responseData => {
        console.log(responseData)
        this.ngOnInit();
      }
    );
  }

  selectAddress(id: number) {
    localStorage.setItem("Address_ID", <string><any>id);

    this.toastr.success("Address Selected");
    this.router.navigate(['HomePage/Kart/PaymentMode']);
  }

  addAddress() {
    this.router.navigate(['HomePage/Kart/Address/AddAddress']);
  }




  ngOnInit() {
    console.log("init");
    this._address.customerAddress()
      .subscribe((data: any[]) => {
      this.addressList = data
      }

      );
  }

}

import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { AddressService } from 'src/app/Services/address.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-address',
  templateUrl: './add-address.component.html',
  styleUrls: ['./add-address.component.css']
})
export class AddAddressComponent implements OnInit {

  constructor(private _address: AddressService, private router: Router) { }


  addAddress(nf: NgForm) {
    this._address.addAddress(nf.value).subscribe(
      responseData => {
        console.log(responseData)
        this.router.navigateByUrl('', { skipLocationChange: true }).then(() =>
          this.router.navigate(['HomePage/Kart/Address'])); 
      }
    );
  }

  ngOnInit() {
  }

}

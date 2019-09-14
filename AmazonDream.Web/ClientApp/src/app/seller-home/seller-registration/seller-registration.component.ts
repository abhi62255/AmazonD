import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { SellerRegistrationService } from 'src/app/Services/seller-registration.service';

@Component({
  selector: 'app-seller-registration',
  templateUrl: './seller-registration.component.html',
  styleUrls: ['./seller-registration.component.css']
})
export class SellerRegistrationComponent implements OnInit {

  constructor(private sellerService: SellerRegistrationService) { }

  
  addSeller(nf: NgForm) {
    this.sellerService.addSellerDB(nf.value).subscribe(
      responseData => {
        console.log(responseData)
      }
    );
  }

  ngOnInit() {
  }

}

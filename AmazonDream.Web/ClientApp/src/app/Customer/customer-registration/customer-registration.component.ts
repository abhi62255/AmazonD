import { Component, OnInit } from '@angular/core';
import { CustomerRegistrationService } from 'src/app/Services/customer-registration.service';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-customer-registration',
  templateUrl: './customer-registration.component.html',
  styleUrls: ['./customer-registration.component.css']
})
export class CustomerRegistrationComponent implements OnInit {

  constructor(private customerRegistration: CustomerRegistrationService) { }

  addCustomer(nf: NgForm) {
    this.customerRegistration.addCustomerDB(nf.value).subscribe(
      responseData => {
        console.log(responseData)
      }
    );
  }

  ngOnInit() {
  }

}

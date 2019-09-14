import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { CustomerRegistrationService } from 'src/app/Services/customer-registration.service';

@Component({
  selector: 'app-customer-registration',
  templateUrl: './customer-registration.component.html',
  styleUrls: ['./customer-registration.component.css']
})
export class CustomerRegistrationComponent implements OnInit {

  constructor(private customerRegService: CustomerRegistrationService) { }

  addCustomer(nf: NgForm) {
    this.customerRegService.addCustomerDB(nf.value).subscribe(
      responseData => {
        console.log(responseData)
      }
    );      //calling service method
  }


  ngOnInit() {
  }

}

import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { LoginService } from 'src/app/Services/login.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  constructor(private login: LoginService, private router: Router) { }

  loginF(nf: NgForm) {
    this.login.login(nf.value).subscribe(
      responseData => {
        console.log(responseData)
        if (responseData == "Admin") {
          console.log("Admin");
          this.router.navigate(['AdminHome'])
        }
        else if (responseData == "Seller") {
          console.log("Seller");
          this.router.navigate(['SellerHome'])
        }
        else if (responseData == "SellerPending") {
          console.log("SellerPending");
        }
        else if (responseData == "SellerDeleted") {
          console.log("SellerDeleted");
        }
        else if (responseData == "Customer") {
          console.log("Customer");
          this.router.navigate(['HomePage'])
        }
        else {
          console.log("Wrong User Crendtials");

        }

      }
    );
  }


  ngOnInit() {
  }

}

import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { LoginService } from 'src/app/Services/login.service';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  constructor(private login: LoginService, private router: Router, private toastr: ToastrService) { }

  user: any;

  loginF(nf: NgForm) {
    this.login.login(nf.value).subscribe(
      responseData => {
        console.log(responseData)
        this.user = <string><any>responseData;
        if (this.user != null) {
          this.user = this.user.split(",");       //Seperating user and ID from response
          console.log(this.user[0] + ' ' + this.user[1]);
        }
      
        
        localStorage.removeItem("Seller_ID");
        localStorage.removeItem("Customer_ID");
        if (this.user == null) {
          console.log("Wrong User Crendtials");
          this.toastr.error("Wrong User Crendtials");
        
        }
        else if (this.user[0] == "Admin") {
          console.log("Admin");
          localStorage.setItem("Login", "true");
          this.router.navigate(['AdminHome'])
        }
        else if (this.user[0] == "Seller") {
          console.log("Seller");
          localStorage.setItem("Seller_ID", this.user[1]);
          localStorage.setItem("Login", "true");
          this.router.navigate(['SellerHome'])
        }
        else if (this.user[0] == "SellerPending") {
          console.log("SellerPending");
        }
        else if (this.user[0] == "SellerDeleted") {
          console.log("SellerDeleted");
        }
        else if (this.user[0] == "Customer") {
          console.log("Customer");
          localStorage.setItem("Customer_ID", this.user[1]);
          localStorage.setItem("Login", "true");
          this.router.navigate(['HomePage/Product'])
        }
       

      }
    );
  }


  ngOnInit() {
  }

}

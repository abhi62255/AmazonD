import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-logout',
  templateUrl: './logout.component.html',
  styleUrls: ['./logout.component.css']
})
export class LogoutComponent implements OnInit {

  constructor(private router: Router) { }

  logout() {
    localStorage.removeItem("Customer_ID");
    localStorage.removeItem("Product_ID");
    localStorage.removeItem("Seller_ID");
    localStorage.removeItem("Admin");
    localStorage.removeItem("Login");
    localStorage.removeItem("Address_ID");
    localStorage.removeItem("PaymentMode");
   

    this.router.navigate(['HomePage/Login']);
  }

  ngOnInit() {
    this.logout();
  }

}

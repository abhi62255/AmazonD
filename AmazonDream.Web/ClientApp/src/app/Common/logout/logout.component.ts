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
    localStorage.removeItem("Login");

    this.router.navigate(['HomePage/Login']);
  }

  ngOnInit() {
    this.logout();
  }

}

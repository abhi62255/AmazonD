import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-seller-home',
  templateUrl: './seller-home.component.html',
  styleUrls: ['./seller-home.component.css']
})
export class SellerHomeComponent implements OnInit {

  constructor(private router: Router) { }

  ngOnInit() {
    if (localStorage.getItem("Admin")) {
      this.router.navigate(['AdminHome']);
    }
    if (localStorage.getItem("Customer_ID")) {
      this.router.navigate(['HomePage/Product']);
    }
  }

}

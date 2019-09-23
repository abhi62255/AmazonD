import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-admin-home',
  templateUrl: './admin-home.component.html',
  styleUrls: ['./admin-home.component.css']
})
export class AdminHomeComponent implements OnInit {

  constructor(private router: Router) { }

  ngOnInit() {
    if (localStorage.getItem("Seller_ID")) {
      this.router.navigate(['SellerHome']);
    }
    if (!localStorage.getItem("Admin")) {
      this.router.navigate(['HomePage/Product']);
    }
  }

}

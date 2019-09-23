import { Component, OnInit, ViewChild } from '@angular/core';
import { NotificationService } from 'src/app/Services/notification.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-home-page',
  templateUrl: './home-page.component.html',
  styleUrls: ['./home-page.component.css']
})
export class HomePageComponent implements OnInit {

  constructor(private _notificationService: NotificationService, private router: Router) { }

  public Name: string;

  public LoginFlag: string = localStorage.getItem("Login");


  Search() {
    this._notificationService.notifyProductAddedToCart(this.Name);
  }
  
  ngOnInit() {
    if (localStorage.getItem("Seller_ID")) {
      this.router.navigate(['SellerHome']);
    }
    if (localStorage.getItem("Admin")) {
      this.router.navigate(['AdminHome']);
    }

  }

}

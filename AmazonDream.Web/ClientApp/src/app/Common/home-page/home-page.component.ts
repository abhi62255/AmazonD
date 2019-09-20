import { Component, OnInit, ViewChild } from '@angular/core';
import { NotificationService } from 'src/app/Services/notification.service';

@Component({
  selector: 'app-home-page',
  templateUrl: './home-page.component.html',
  styleUrls: ['./home-page.component.css']
})
export class HomePageComponent implements OnInit {

  constructor(private _notificationService: NotificationService) { }

  public Name: string;

  public LoginFlag: string = localStorage.getItem("Login");


  Search() {
    this._notificationService.notifyProductAddedToCart(this.Name);
  }
  
  ngOnInit() {

  }

}

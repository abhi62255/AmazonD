import { Component, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { ProductService } from 'src/app/Services/product.service';
import { ProductSuggestionsService } from 'src/app/Services/product-suggestions.service';
import { ConstantsService } from 'src/app/Services/constants.service';
import { NotificationService } from 'src/app/Services/notification.service';

@Component({
  selector: 'app-home-page',
  templateUrl: './home-page.component.html',
  styleUrls: ['./home-page.component.css']
})
export class HomePageComponent implements OnInit {

  constructor(private _notificationService: NotificationService) { }

  public Name: string;


  Search() {
    this._notificationService.notifyProductAddedToCart(this.Name);
  }
  
  ngOnInit() {

  }

}

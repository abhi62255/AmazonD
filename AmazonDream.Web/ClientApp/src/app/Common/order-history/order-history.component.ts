import { Component, OnInit } from '@angular/core';
import { OrderPlacedService } from 'src/app/Services/order-placed.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-order-history',
  templateUrl: './order-history.component.html',
  styleUrls: ['./order-history.component.css']
})
export class OrderHistoryComponent implements OnInit {

  constructor(private _orderPlaced: OrderPlacedService, private router: Router) { }

  public orderHistory: any[];

  ngOnInit() {

    this._orderPlaced.placedOrderCustomer()
      .subscribe((data: any[]) => this.orderHistory = data);
  }

}

import { Component, OnInit } from '@angular/core';
import { OrderPlacedService } from 'src/app/Services/order-placed.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-orders',
  templateUrl: './orders.component.html',
  styleUrls: ['./orders.component.css']
})
export class OrdersComponent implements OnInit {

  constructor(private _receivedOrder: OrderPlacedService, private router: Router) { }



  public orderList: any[];
  viewreceivedOrder() {
    this._receivedOrder.placedOrderAdmin()
      .subscribe((data: any[]) => this.orderList = data);

    console.log(this.orderList);
  }
  ngOnInit() {
    this.viewreceivedOrder();
  }

}

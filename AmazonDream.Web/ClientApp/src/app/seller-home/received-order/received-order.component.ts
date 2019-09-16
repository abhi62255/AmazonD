import { Component, OnInit } from '@angular/core';
import { OrderPlacedService } from 'src/app/Services/order-placed.service';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-received-order',
  templateUrl: './received-order.component.html',
  styleUrls: ['./received-order.component.css']
})
export class ReceivedOrderComponent implements OnInit {

  constructor(private _receivedOrder: OrderPlacedService, private router: Router) { }


  public orderList: any[];
  viewPendingProducts() {
    this._receivedOrder.receivedOrder()
      .subscribe((data: any[]) => this.orderList = data);

    console.log(this.orderList);
  }

  updateStatus(status: NgForm, id: number) {
    this._receivedOrder.updateStatus(status.value.status, id).subscribe(
      responseData => {
        console.log(responseData)
      }
    );
    this.router.navigate(['SellerHome/ViewProduct']);
  }


  ngOnInit() {
    this.viewPendingProducts();
  }

}

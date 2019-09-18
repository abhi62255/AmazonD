import { Component, OnInit } from '@angular/core';
import { KartService } from 'src/app/Services/kart.service';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';
import { of } from 'rxjs';

@Component({
  selector: 'app-kart',
  templateUrl: './kart.component.html',
  styleUrls: ['./kart.component.css']
})
export class KartComponent implements OnInit {

  constructor(private _kart: KartService, private toastr: ToastrService, private router: Router) { }

  public productList: any[];
  result: string;
  TotalAmount: number =0;

  getKartByCustomerId() {
    this._kart.getKartByCustomerId()
      .subscribe((data) => {
      this.productList = data
        console.log(this.productList);
        this.TotalAmount = 0;
          for (let product of this.productList) {
              this.TotalAmount += product.amount;
              console.log(this.TotalAmount);
          }
      });
  }


  updateKartQuantity(action: string, id: number) {
    this._kart.updateKartQuantity(action, id).subscribe(
      responseData => {
        console.log(responseData)
        this.result = <string><any>responseData;
        if (this.result == "Product Not Available") {
          this.toastr.error(this.result);
        }
        this.ngOnInit();

      }
    );
  }

  removeItemFromKart(id: number) {
    this._kart.removeItemFromKart(id).subscribe(
      responseData => {
        console.log(responseData)
        this.ngOnInit();
      }
    );
  }

  clearKart() {
    this._kart.clearKart().subscribe(
      responseData => {
        console.log(responseData)
        this.ngOnInit();
      }
    );
  }

  next() {
    this.router.navigate(['HomePage/Kart/Address']);
  }



  ngOnInit() {
    this.getKartByCustomerId();
  }

}

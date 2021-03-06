import { Component, OnInit } from '@angular/core';
import { SellerServiceService } from 'src/app/Services/seller-service.service';
import { ConstantsService } from 'src/app/Services/constants.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-seller-requests',
  templateUrl: './seller-requests.component.html',
  styleUrls: ['./seller-requests.component.css']
})
export class SellerRequestsComponent implements OnInit {

  constructor(private _sellerService: SellerServiceService) { }

  public sellerList: any[];
  getSeller() {
    this._sellerService.getSeller("Pending")
      .subscribe((data: any[]) => this.sellerList = data);
  }

  respondSellerRequest(status: string, id: number) {
    this._sellerService.respondSellerRequest(status, id).subscribe(
      responseData => {
        console.log(responseData)
        this.ngOnInit();
      }
    );
  }


  ngOnInit() {
    this.getSeller();
  }

}

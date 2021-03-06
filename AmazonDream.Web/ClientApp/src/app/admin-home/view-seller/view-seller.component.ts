import { Component, OnInit } from '@angular/core';
import { ConstantsService } from 'src/app/Services/constants.service';
import { SellerServiceService } from 'src/app/Services/seller-service.service';

@Component({
  selector: 'app-view-seller',
  templateUrl: './view-seller.component.html',
  styleUrls: ['./view-seller.component.css']
})
export class ViewSellerComponent implements OnInit {

  constructor(private _sellerService: SellerServiceService) { }


  public sellerList: any[];
  getSeller() {
    this._sellerService.getSeller("Accepted")
      .subscribe((data: any[]) => this.sellerList = data);
  }

  sellerStatus(status: string, id: number) {
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

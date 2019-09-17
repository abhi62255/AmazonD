import { Component, OnInit } from '@angular/core';
import { ProductService } from 'src/app/Services/product.service';
import { ConstantsService } from 'src/app/Services/constants.service';

@Component({
  selector: 'app-trend-request',
  templateUrl: './trend-request.component.html',
  styleUrls: ['./trend-request.component.css']
})
export class TrendRequestComponent implements OnInit {

  constructor(private _productService: ProductService, private _constant: ConstantsService) { }


  public productList: any[];

  trendRequestProduct() {
    this._productService.getTrendRequestProductsAll()
      .subscribe((data: any[]) => this.productList = data);
  }


  productTrend(status: string, id: number) {
    this._productService.trendProduct(status, id)
      .subscribe((data: any[]) => this.productList = data);
    this.ngOnInit();
  }


  ngOnInit() {
    this.trendRequestProduct();
  }

}

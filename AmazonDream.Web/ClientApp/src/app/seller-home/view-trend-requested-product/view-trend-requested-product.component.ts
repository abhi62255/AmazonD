import { Component, OnInit } from '@angular/core';
import { ProductService } from 'src/app/Services/product.service';

@Component({
  selector: 'app-view-trend-requested-product',
  templateUrl: './view-trend-requested-product.component.html',
  styleUrls: ['./view-trend-requested-product.component.css']
})
export class ViewTrendRequestedProductComponent implements OnInit {

  constructor(private _productService: ProductService) { }

  public productList: any[];
  viewProduct() {
    this._productService.getTrendRequestedProducts()
      .subscribe((data: any[]) => this.productList = data);

    console.log(this.productList);
  }


  ngOnInit() {
    this.viewProduct();
  }

}

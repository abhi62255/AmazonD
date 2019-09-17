import { Component, OnInit } from '@angular/core';
import { ProductService } from 'src/app/Services/product.service';
import { ConstantsService } from 'src/app/Services/constants.service';

@Component({
  selector: 'app-trending-product',
  templateUrl: './trending-product.component.html',
  styleUrls: ['./trending-product.component.css']
})
export class TrendingProductComponent implements OnInit {

  constructor(private _productService: ProductService,) { }

  public productList: any[];

  trendProduct() {
    this._productService.getTrendingProductsAll()
      .subscribe((data: any[]) => this.productList = data);
  }

  productTrend(id: number) {
    this._productService.trendProduct('False', id).subscribe(
      responseData => {
        console.log(responseData)
        this.ngOnInit();
      }
    );
  }

  ngOnInit() {
    this.trendProduct();
  }

}

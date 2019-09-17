import { Component, OnInit } from '@angular/core';
import { ProductService } from 'src/app/Services/product.service';

@Component({
  selector: 'app-view-trending-product',
  templateUrl: './view-trending-product.component.html',
  styleUrls: ['./view-trending-product.component.css']
})
export class ViewTrendingProductComponent implements OnInit {

  constructor(private _productService: ProductService) { }

  public productList: any[];
  viewProduct() {
    this._productService.getTrendingProducts()
      .subscribe((data: any[]) => this.productList = data);

    console.log(this.productList);
  }


  removeTrendingProduct(id: number) {
    this._productService.trendRequest("False", id).subscribe(
      responseData => {
        console.log(responseData)
        this.ngOnInit();

      }
    );
  }


  ngOnInit() {
    this.viewProduct();
  }

}

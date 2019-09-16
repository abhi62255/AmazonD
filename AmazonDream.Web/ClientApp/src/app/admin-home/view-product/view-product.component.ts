import { Component, OnInit } from '@angular/core';
import { ProductService } from 'src/app/Services/product.service';
import { ConstantsService } from 'src/app/Services/constants.service';

@Component({
  selector: 'app-view-product',
  templateUrl: './view-product.component.html',
  styleUrls: ['./view-product.component.css']
})
export class ViewProductComponent implements OnInit {

  constructor(private _productService: ProductService, private _constant: ConstantsService) { }

  public productList: any[];

  getProduct() {
    this._productService.getProduct("Accepted")
      .subscribe((data: any[]) => this.productList = data);
  }


  respondProduct(status: string, id: number) {
    this._productService.respondProductRequest(status, id)
      .subscribe((data: any[]) => this.productList = data);
  }

  trendProduct(id: number) {
    this._productService.trendProduct("True", id)
      .subscribe((data: any[]) => this.productList = data);
  }

  ngOnInit() {
    this.getProduct();
  }

}

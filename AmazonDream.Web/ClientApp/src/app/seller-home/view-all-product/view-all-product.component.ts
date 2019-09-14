import { Component, OnInit } from '@angular/core';
import { ProductService } from 'src/app/Services/product.service';

@Component({
  selector: 'app-view-all-product',
  templateUrl: './view-all-product.component.html',
  styleUrls: ['./view-all-product.component.css']
})
export class ViewAllProductComponent implements OnInit {

  constructor(private _productService: ProductService) { }

  public productList: any[];
  viewAllProduct() {
    this._productService.getAcceptedProducts()
      .subscribe((data: any[]) => this.productList = data);

    console.log(this.productList);
  }
  ngOnInit() {
    this.viewAllProduct();
    console.log("ProductList");
    console.log(this.productList);
  }

}

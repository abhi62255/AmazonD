import { Component, OnInit } from '@angular/core';
import { ProductService } from 'src/app/Services/product.service';
import { ConstantsService } from 'src/app/Services/constants.service';

@Component({
  selector: 'app-pending-product',
  templateUrl: './pending-product.component.html',
  styleUrls: ['./pending-product.component.css']
})
export class PendingProductComponent implements OnInit {

  constructor(private _productService: ProductService, private _constant: ConstantsService) { }

  public productList: any[];

  getProduct() {
    this._productService.getProduct("Pending")
      .subscribe((data: any[]) => this.productList = data);
  }


  respondProductRequest(status: string, id: number) {
    this._productService.respondProductRequest(status, id)
      .subscribe((data: any[]) => this.productList = data);
  }

  ngOnInit() {
    this.getProduct();

  }

}

import { Component, OnInit } from '@angular/core';
import { ProductService } from 'src/app/Services/product.service';

@Component({
  selector: 'app-view-pending-product',
  templateUrl: './view-pending-product.component.html',
  styleUrls: ['./view-pending-product.component.css']
})
export class ViewPendingProductComponent implements OnInit {

  constructor(private _productService: ProductService) { }

  public productList: any[];
  viewPendingProducts() {
    this._productService.getPendingProducts()
      .subscribe((data: any[]) => this.productList = data);

    console.log(this.productList);
  }

  deleteProduct(id: number) {
    console.log(id);
    this._productService.deleteProduct(id).subscribe(
      responseData => {
        console.log(responseData)
      }
    );
  }

  ngOnInit() {
    this.viewPendingProducts();

  }

}

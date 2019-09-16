import { Component, OnInit } from '@angular/core';
import { ProductService } from 'src/app/Services/product.service';
import { ConstantsService } from 'src/app/Services/constants.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-view-all-product',
  templateUrl: './view-all-product.component.html',
  styleUrls: ['./view-all-product.component.css']
})
export class ViewAllProductComponent implements OnInit {

  constructor(private _productService: ProductService, private _constant: ConstantsService, private router: Router) { }

  public productList: any[];
  viewAllProduct() {
    this._productService.getAcceptedProducts()
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

  trendRequest(id: number) {
    console.log(id);
    this._productService.trendRequest("Requested",id).subscribe(
      responseData => {
        console.log(responseData)
      }
    );
  }

  constProductID(id: number) {          //to set Product_ID in Constant services
    console.log(id);
    this._constant.Product_ID = id;
    this.router.navigate(["SellerHome/ViewProduct/UpdateValues"]);

  }

  ngOnInit() {
    this.viewAllProduct();
  }

}

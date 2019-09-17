import { Component, OnInit } from '@angular/core';
import { ConstantsService } from 'src/app/Services/constants.service';
import { ProductService } from 'src/app/Services/product.service';
import { KartService } from 'src/app/Services/kart.service';
import { ToastrService } from 'ngx-toastr';


@Component({
  selector: 'app-product-home',
  templateUrl: './product-home.component.html',
  styleUrls: ['./product-home.component.css']
})
export class ProductHomeComponent implements OnInit {

  constructor(public _constant: ConstantsService, public _product: ProductService, public _kart: KartService, private toastr: ToastrService) { }

  public product: any;
  public productPicture: any;

  getProductDetails() {
    this._product.getProductDetails()
      .subscribe((data: any) => this.product = data);
    console.log(this.product);
  }
  getProductPicture() {
    this._product.getProductPicture()
      .subscribe((data: any) => this.productPicture = data);
    console.log(this.productPicture);
  }

  addProductToKart(id: number) {
    console.log("compone")
    this._kart.addProductToKart(id).subscribe(
      responseData => {
        console.log(responseData)
        this.toastr.success("Product Added To Kart");
      }
    );
  }

  ngOnInit() {
    console.log(localStorage.getItem("Product_ID"));
    this.getProductDetails();
    this.getProductPicture();
  }

}

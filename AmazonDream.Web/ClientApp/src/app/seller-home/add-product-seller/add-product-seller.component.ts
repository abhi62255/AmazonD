import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms'
import { ProductService } from 'src/app/Services/product.service';
import { Router } from '@angular/router';
import { ConstantsService } from 'src/app/Services/constants.service';


@Component({
  selector: 'app-add-product-seller',
  templateUrl: './add-product-seller.component.html',
  styleUrls: ['./add-product-seller.component.css']
})
export class AddProductSellerComponent implements OnInit {

  constructor(private productService: ProductService, private router: Router, private _constant: ConstantsService) { }

  addProduct(product: NgForm) {

    product.value.Seller_ID = 1;
    this.productService.addProduct(product.value).subscribe(
      responseData => {
        console.log("productID");
        console.log(responseData)

        this._constant.Product_ID = <number><any>responseData.toString();
      }
    );
    console.log(product.value);
    this.router.navigate(['SellerHome/AddProductPicture']);
  }

  ngOnInit() {
  }

}

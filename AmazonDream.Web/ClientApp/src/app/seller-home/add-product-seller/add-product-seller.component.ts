import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms'
import { ProductService } from 'src/app/Services/product.service';


@Component({
  selector: 'app-add-product-seller',
  templateUrl: './add-product-seller.component.html',
  styleUrls: ['./add-product-seller.component.css']
})
export class AddProductSellerComponent implements OnInit {

  constructor(private productService: ProductService) { }

  addProduct(product: NgForm) {

    product.value.Seller_ID = 1;
    this.productService.addProduct(product.value).subscribe(
      responseData => {
        console.log(responseData)
      }
    );
    console.log(product.value);
  }

  ngOnInit() {
  }

}

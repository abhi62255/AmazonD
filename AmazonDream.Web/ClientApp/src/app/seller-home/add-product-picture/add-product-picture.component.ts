import { Component, OnInit } from '@angular/core';
import { ProductService } from 'src/app/Services/product.service';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-product-picture',
  templateUrl: './add-product-picture.component.html',
  styleUrls: ['./add-product-picture.component.css']
})
export class AddProductPictureComponent implements OnInit {

  constructor(private productService: ProductService) { }

  addProductPicture(productPicture: NgForm) {

    this.productService.addProductPicture(productPicture.value).subscribe(
      responseData => {
        console.log(responseData)
      }
    );
    console.log(productPicture.value);
  }

  ngOnInit() {
  }

}

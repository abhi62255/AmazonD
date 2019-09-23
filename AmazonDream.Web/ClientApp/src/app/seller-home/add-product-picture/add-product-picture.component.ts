import { Component, OnInit } from '@angular/core';
import { ProductService } from 'src/app/Services/product.service';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-add-product-picture',
  templateUrl: './add-product-picture.component.html',
  styleUrls: ['./add-product-picture.component.css']
})
export class AddProductPictureComponent implements OnInit {

  constructor(private productService: ProductService, private toastr: ToastrService) { }

  addProductPicture(productPicture: NgForm) {

    this.productService.addProductPicture(productPicture.value).subscribe(
      responseData => {
        console.log(responseData)
        this.toastr.success("Picture Added");
      }
    );
    console.log(productPicture.value);
  }

  ngOnInit() {
  }

}

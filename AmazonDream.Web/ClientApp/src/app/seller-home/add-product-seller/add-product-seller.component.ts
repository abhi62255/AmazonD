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

  constructor(private productService: ProductService, private router: Router) { }

  Product_ID: string;
  Descrption: string = "";      //to store in database
  DescrptionView                //make array to diplay at realtime
  addProduct(product: NgForm) {

    product.value.Seller_ID = localStorage.getItem("Seller_ID");
    this.Descrption = this.Descrption.substring(0, this.Descrption.length - 1);       //removing , from end of descrption
    product.value.ProductDescription = this.Descrption;

    this.productService.addProduct(product.value).subscribe(
      responseData => {
        console.log("productID");
        console.log(responseData)

        this.Product_ID = responseData.toString();
        localStorage.setItem("Product_ID", this.Product_ID);      //string and number locha
      }
    );
    console.log(product.value);
    this.router.navigate(['SellerHome/AddProductPicture']);
  }


  addDescription(descrption: NgForm) {
    console.log("Descrption");
    this.Descrption += descrption.value.property + ' : ' + descrption.value.value + ',';    //Creating descrption  in string
    this.DescrptionView = this.Descrption.split(",");       //creating array to display

    console.log(this.Descrption);
  }

  ngOnInit() {
  }

}

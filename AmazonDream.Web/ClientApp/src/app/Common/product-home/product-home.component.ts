import { Component, OnInit } from '@angular/core';
import { ConstantsService } from 'src/app/Services/constants.service';
import { ProductService } from 'src/app/Services/product.service';
import { KartService } from 'src/app/Services/kart.service';
import { ToastrService } from 'ngx-toastr';
import { WishListService } from 'src/app/Services/wish-list.service';
import { Wish } from 'src/app/Model/Wish';
import { PrevisitService } from 'src/app/Services/previsit.service';


@Component({
  selector: 'app-product-home',
  templateUrl: './product-home.component.html',
  styleUrls: ['./product-home.component.css']
})
export class ProductHomeComponent implements OnInit {

  constructor(public _constant: ConstantsService, public _product: ProductService, public _kart: KartService, private toastr: ToastrService, private _wish: WishListService, private _previsit: PrevisitService) { }

  public product: any;
  public productPicture: any;
  public result: string;
  public wish = new Wish();
  public Descrption;


  getProductDetails() {
    if (localStorage.getItem("Customer_ID")) {          //add product to previst if Customer is login
      this._previsit.addPrevisit().subscribe();
    }                          
    this._product.getProductDetails()
      .subscribe((data: any) => {
        this.product = data
        this.Descrption = data.productDescription.split(",");
      });
    console.log(this.product);
  }
  getProductPicture() {
    this._product.getProductPicture()
      .subscribe((data: any) => this.productPicture = data);
    console.log(this.productPicture);
  }

  addProductToKart(id: number) {
    console.log("component");
    this._kart.addProductToKart(id).subscribe(
      responseData => {
        console.log(responseData)
        this.result = <string><any>responseData;      //errro on not available
        if (this.result == "Product Added to Kart")
          this.toastr.success(this.result);
        else
          this.toastr.error(this.result);
      }
    );
  }

  addWish(id: number) {
    this.wish.Product_ID = id;
    this.wish.Customer_ID = <number><any>localStorage.getItem("Customer_ID");
    this._wish.addWish(this.wish).subscribe();
    this.toastr.info("Added to Wish");

  }

  ngOnInit() {
    console.log(localStorage.getItem("Product_ID"));
    this.getProductDetails();
    this.getProductPicture();
  }

}

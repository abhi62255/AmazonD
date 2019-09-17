import { Component, OnInit } from '@angular/core';
import { ProductSuggestionsService } from 'src/app/Services/product-suggestions.service';
import { Router } from '@angular/router';
import { ConstantsService } from 'src/app/Services/constants.service';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css']
})
export class ProductsComponent implements OnInit {

  constructor(public router: Router, private _productSuggestion: ProductSuggestionsService, public _constant: ConstantsService) { }

  public productList: any[];
  public productListAll: any[];



  productSuggestionKnown() {          //suggested product for known user
    this._productSuggestion.GetSuggestedProductsKnownUser()
      .subscribe((data: any[]) => this.productList = data);

    console.log(this.productList);
  }

  productSuggestionUnKnown() {      //suggested product for Unknown user
    this._productSuggestion.GetSuggestedProductsUnknownUser()
      .subscribe((data: any[]) => this.productList = data);

    console.log(this.productList);
  }


  productSuggestionAll() {      //suggested product for Unknown user
    this._productSuggestion.GetSuggestedProductsAll()
      .subscribe((data: any[]) => this.productListAll = data);

    console.log(this.productList);
  }


  productHome(id: number) {
    localStorage.setItem("Product_ID", <string><any>id);
    this.router.navigate(['HomePage/ProductHome']);
  }


  ngOnInit() {
    this.productSuggestionAll();
    if (localStorage.getItem("Customer_ID") == null) {
      this.productSuggestionUnKnown();
    }
    else {
      this.productSuggestionKnown();
    }

  }

}

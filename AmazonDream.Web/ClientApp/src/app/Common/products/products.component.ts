import { Component, OnInit, Input, OnDestroy } from '@angular/core';
import { ProductSuggestionsService } from 'src/app/Services/product-suggestions.service';
import { Router } from '@angular/router';
import { ConstantsService } from 'src/app/Services/constants.service';
import { NotificationService } from 'src/app/Services/notification.service';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css']
})
export class ProductsComponent implements OnInit,OnDestroy {

  constructor(public router: Router, private _productSuggestion: ProductSuggestionsService, public _constant: ConstantsService, private _notificationService: NotificationService) { }

  public productList: any[];
  public productListAll: any[];
  public Name: string;
  public subscriptions: any[];
  public ProductListStable: any[];
  public ProductListAllStable: any[];




  productSuggestionKnown() {          //suggested product for known user
    this._productSuggestion.GetSuggestedProductsKnownUser()
      .subscribe((data: any[]) => {
        this.ProductListStable = data;
        this.productList = this.ProductListStable;
      });

    console.log(this.ProductListStable);
  }

  productSuggestionUnKnown() {      //suggested product for Unknown user
    this._productSuggestion.GetSuggestedProductsUnknownUser()
      .subscribe((data: any[]) => {
        this.ProductListStable = data;
        this.productList = this.ProductListStable;

      });

    console.log(this.ProductListStable);
  }


  productSuggestionAll() {      //suggested product for Unknown user
    this._productSuggestion.GetSuggestedProductsAll()
      .subscribe((data: any[]) => {
        this.ProductListAllStable = data;
        this.productListAll = this.ProductListAllStable;

      });

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

    this.subscriptions = [];

    this.subscriptions.push(
      this._notificationService.productAddedToCartNotification.subscribe((SearchTag: string) => {
        this.productList = this.ProductListStable;
        if (SearchTag != '') {        //need to handel backspace problem
          this.productListAll = null;
          this.productList = this.productList.filter(res => {
            return res.productName.toLocaleLowerCase().match(SearchTag.toLocaleLowerCase());
          });
        } else if (SearchTag == '') {
          //this.productList = this.productList;
          //this.ngOnInit();
          this.productListAll = this.ProductListAllStable;
          this.productList = this.ProductListStable;
        }
        console.log(this.productList);


      })
    );

  }
  ngOnDestroy() {
    this.subscriptions.forEach((s) => {
      s.unsubscribe();
    });
  }

}

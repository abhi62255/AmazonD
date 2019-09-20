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
  public subscriptions: any[];
  public ProductListStable: any[];
  public ProductListAllStable: any[];



  removingDuplication() {
    this.productList.forEach(product => {   //to remove similar product from One of the list
      let index = 0;
      console.log(product.id);
      this.productListAll.forEach(productAll => {
        console.log(productAll.id);
        if (product.id == productAll.id) {
          console.log("Remove");
          console.log(productAll.id);
          this.productListAll.splice(index, 1);
          index += 1;
          return true;

        }
      });
    });
  }



  productSuggestionKnown() {          //suggested product for known user
    this._productSuggestion.GetSuggestedProductsKnownUser()
      .subscribe((data: any[]) => {
        this.ProductListStable = data;
        this.productList = this.ProductListStable;

        this.removingDuplication();
        console.log(this.productListAll);
        console.log(this.productList);

      });

    console.log(this.ProductListStable);
  }

  productSuggestionUnKnown() {      //suggested product for Unknown user
    this._productSuggestion.GetSuggestedProductsUnknownUser()
      .subscribe((data: any[]) => {
        this.ProductListStable = data;
        this.productList = this.ProductListStable;

        this.removingDuplication();
        
      });

    console.log(this.ProductListStable);
  }


  productSuggestionAll() {      //suggested product for All user
    this._productSuggestion.GetSuggestedProductsAll()
      .subscribe((data: any[]) => {
        this.ProductListAllStable = data;
        this.productListAll = this.ProductListAllStable;

        this.removingDuplication();
        
      });

    console.log(this.productList);
  }


  productHome(id: number) {
    localStorage.setItem("Product_ID", <string><any>id);
    this.router.navigate(['HomePage/ProductHome']);
  }



  ngOnInit() {
    this.productListAll = [];
    this.productList = [];
    this.ProductListStable = [];
    this.ProductListAllStable = [];


    this.productSuggestionAll();

    if (localStorage.getItem("Customer_ID") == null) {
      this.productSuggestionUnKnown();
    }
    else {
      this.productSuggestionKnown();
    }



    console.log(this.productListAll);
    console.log(this.productList);

    //for removing similar products
    //this.productListAll.forEach((obj) => {
    //  var existNotification = this.productList.find(({ id }) => obj.id === id);
    //  let index: number = this.productListAll.indexOf(obj.id);
    //  if (existNotification) {
    //    this.productListAll.splice(index, 1);
    //  }
    //});

    this.subscriptions = [];      //Notification service

    this.subscriptions.push(
      this._notificationService.productAddedToCartNotification.subscribe((SearchTag: string) => {
        this.productList = this.ProductListStable;
        this.productListAll = this.ProductListAllStable;
        SearchTag = SearchTag.toLocaleLowerCase();

        if (SearchTag != '') {            //filtering of products productList
          this.productList = this.productList.filter(res => {
            return res.productName.toLocaleLowerCase().match(SearchTag.toLocaleLowerCase());
          });
        }
        if (SearchTag != '') {            //filtering of products in productListAll
          this.productListAll = this.productListAll.filter(res => {
            return res.productName.toLocaleLowerCase().match(SearchTag.toLocaleLowerCase());
          });
        }
        else if (SearchTag == '') {
        
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

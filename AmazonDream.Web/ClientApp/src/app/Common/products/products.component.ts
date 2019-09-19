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



  productSuggestionKnown() {          //suggested product for known user
    this._productSuggestion.GetSuggestedProductsKnownUser()
      .subscribe((data: any[]) => {
        this.productList = data
      });

    console.log(this.productList);
  }

  productSuggestionUnKnown() {      //suggested product for Unknown user
    this._productSuggestion.GetSuggestedProductsUnknownUser()
      .subscribe((data: any[]) => this.productList = data);

    console.log(this.productList);
  }


  productSuggestionAll() {      //suggested product for Unknown user
    this._productSuggestion.GetSuggestedProductsAll()
      .subscribe((data: any[]) => {
        this.productListAll = data
      });

    console.log(this.productList);
  }


  productHome(id: number) {
    localStorage.setItem("Product_ID", <string><any>id);
    this.router.navigate(['HomePage/ProductHome']);
  }

  Search() {
    console.log("SEARCH");
    if (this.Name !== '') {
      this.productList = this.productList.filter(res => {
        return res.productName.toLocaleLowerCase().match(this.Name.toLocaleLowerCase());
      });
    } else if (this.Name === '') {
      this.ngOnInit();
    }
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
        
        if (SearchTag != '') {        //need to handel backspace problem
          this.productList = this.productList.filter(res => {
            return res.productName.toLocaleLowerCase().match(SearchTag.toLocaleLowerCase());
          });
        } else if (SearchTag == '') {
          //this.productList = this.productList;
          this.ngOnInit();
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

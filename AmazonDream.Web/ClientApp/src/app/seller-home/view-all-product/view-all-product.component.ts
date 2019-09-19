import { Component, OnInit } from '@angular/core';
import { ProductService } from 'src/app/Services/product.service';
import { ConstantsService } from 'src/app/Services/constants.service';
import { Router, NavigationEnd } from '@angular/router';

@Component({
  selector: 'app-view-all-product',
  templateUrl: './view-all-product.component.html',
  styleUrls: ['./view-all-product.component.css']
})
export class ViewAllProductComponent implements OnInit {
    mySubscription: import("D:/Sagar Rout/AmazonDream-master/AmazonDream.Web/ClientApp/node_modules/rxjs/internal/Subscription").Subscription;

  constructor(private _productService: ProductService, private _constant: ConstantsService, private router: Router) {

    this.router.routeReuseStrategy.shouldReuseRoute = function () {
      return false;
    };

    this.mySubscription = this.router.events.subscribe((event) => {
      if (event instanceof NavigationEnd) {
        // Trick the Router into believing it's last link wasn't previously loaded
        this.router.navigated = false;
      }
    });

  }

  public productList: any[];
  viewAllProduct() {
    this._productService.getAcceptedProducts()
      .subscribe((data: any[]) => this.productList = data );

    console.log(this.productList);
  }

  deleteProduct(id: number) {
    console.log(id);
    this._productService.deleteProduct(id).subscribe(
      responseData => {
        console.log(responseData)
        this.ngOnInit();
      }
    );
  }

  trendRequest(id: number) {
    console.log(id);
    this._productService.trendRequest("Requested",id).subscribe(
      responseData => {
        console.log(responseData)
      }
    );
  }

  constProductID(id: number) {          //to set Product_ID in Constant services
    console.log(id);
    localStorage.setItem("Product_ID", <string><any>id);
    this.router.navigate(["SellerHome/ViewProduct/UpdateValues"]);
  }

  ngOnInit() {
    this.viewAllProduct();
  }

  ngOnDestroy() {
    if (this.mySubscription) {
      this.mySubscription.unsubscribe();
    }
  }

}

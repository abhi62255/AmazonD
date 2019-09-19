import { Component, OnInit } from '@angular/core';
import { SimilarProductsService } from 'src/app/Services/similar-products.service';
import { Router } from '@angular/router';
import { ProductService } from 'src/app/Services/product.service';

@Component({
  selector: 'app-similar-products',
  templateUrl: './similar-products.component.html',
  styleUrls: ['./similar-products.component.css']
})
export class SimilarProductsComponent implements OnInit {

  constructor(private _similar: SimilarProductsService, private router: Router) { }

  productList: any[];


  productHome(id: number) {
    localStorage.setItem("Product_ID", <string><any>id);

    this.router.navigateByUrl('HomePage/RefreshComponent', { skipLocationChange: true }).then(() =>   //first navigate to Refresh component
      this.router.navigate(['HomePage/ProductHome/Reviews']));                        //then to original component


    //this.router.navigate(['HomePage/ProductHome/Reviews']);
  }
  


  ngOnInit() {
    this._similar.getSimilarProducts()
      .subscribe((data: any[]) => this.productList = data);
  }

}

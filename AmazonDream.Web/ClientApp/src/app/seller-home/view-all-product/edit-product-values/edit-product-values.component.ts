import { Component, OnInit, Input } from '@angular/core';
import { ConstantsService } from 'src/app/Services/constants.service';
import { NgForm } from '@angular/forms';
import { ProductService } from 'src/app/Services/product.service';
import { Router } from '@angular/router';
import { ViewAllProductComponent } from '../view-all-product.component';

@Component({
  selector: 'app-edit-product-values',
  templateUrl: './edit-product-values.component.html',
  styleUrls: ['./edit-product-values.component.css']
})
export class EditProductValuesComponent implements OnInit {

  constructor(private productServices: ProductService, private router: Router) { }

  updateValues(nf: NgForm) {
    this.productServices.updateValues(nf.value).subscribe(
      responseData => {
        console.log(responseData)
        this.router.navigateByUrl('HomePage/RefreshComponent', { skipLocationChange: true }).then(() =>
          this.router.navigate(["SellerHome/ViewProduct"])); 
      }
    );
    

    //this.router.navigate(["SellerHome/ViewProduct"]);
  }

 
  ngOnInit() {
  }

}

import { Component, OnInit } from '@angular/core';
import { WishListService } from 'src/app/Services/wish-list.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-wish',
  templateUrl: './wish.component.html',
  styleUrls: ['./wish.component.css']
})
export class WishComponent implements OnInit {

  constructor(private _wish: WishListService, private router: Router) { }

  public wishlist: any;


  removeWish(id: number) {
    this._wish.removeWish(id).subscribe(data => { this.ngOnInit(); });
  }

  productDetails(id: number) {
    localStorage.setItem("Product_ID", <string><any>id);
    this.router.navigate(['HomePage/ProductHome']);
  }


  ngOnInit() {

    this._wish.getWishlist()
      .subscribe((data: any[]) => this.wishlist = data);

  }

}

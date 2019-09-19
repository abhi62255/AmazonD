import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class NotificationService {


  productAddedToCartNotification: Subject<null> = new Subject<null>();

  constructor() {}



  notifyProductAddedToCart(SearchTag: any) {
    this.productAddedToCartNotification.next(SearchTag);
  }
}

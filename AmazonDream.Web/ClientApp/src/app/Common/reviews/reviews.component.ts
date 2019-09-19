import { Component, OnInit } from '@angular/core';
import { ReviewService } from 'src/app/Services/review.service';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-reviews',
  templateUrl: './reviews.component.html',
  styleUrls: ['./reviews.component.css']
})
export class ReviewsComponent implements OnInit {

  constructor(private _review: ReviewService) { }

  reviewList: any[];


  addReview(review: NgForm) {
    review.value.Customer_ID = localStorage.getItem("Customer_ID");
    review.value.Product_ID = localStorage.getItem("Product_ID");
    this._review.addReview(review.value).subscribe(response => { this.ngOnInit() });

  }

  ngOnInit() {
    this._review.getReview()
      .subscribe((data: any[]) => this.reviewList = data);

  }

}

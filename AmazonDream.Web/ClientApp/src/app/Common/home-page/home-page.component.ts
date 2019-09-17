import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ProductService } from 'src/app/Services/product.service';
import { ProductSuggestionsService } from 'src/app/Services/product-suggestions.service';
import { ConstantsService } from 'src/app/Services/constants.service';

@Component({
  selector: 'app-home-page',
  templateUrl: './home-page.component.html',
  styleUrls: ['./home-page.component.css']
})
export class HomePageComponent implements OnInit {

  constructor() { }
  
  ngOnInit() {

  }

}

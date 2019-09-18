import { Component, OnInit } from '@angular/core';
import { PrevisitService } from 'src/app/Services/previsit.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-previsit',
  templateUrl: './previsit.component.html',
  styleUrls: ['./previsit.component.css']
})
export class PrevisitComponent implements OnInit {

  constructor(private _previsit: PrevisitService, private router: Router) { }

  public preVisit: any;


  productDetails(id: number) {
    localStorage.setItem("Product_ID", <string><any>id);
    this.router.navigate(['HomePage/ProductHome']);
  }


  ngOnInit() {
    this._previsit.getPrevisit()
      .subscribe((data: any[]) => this.preVisit = data);

  }

}

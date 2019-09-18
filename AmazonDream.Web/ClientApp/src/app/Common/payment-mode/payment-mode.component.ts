import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-payment-mode',
  templateUrl: './payment-mode.component.html',
  styleUrls: ['./payment-mode.component.css']
})
export class PaymentModeComponent implements OnInit {

  constructor(private toastr: ToastrService, private router: Router) { }

  paymentMode(value: string) {
    localStorage.setItem("PaymentMode", value);
    this.router.navigate(['HomePage/Kart/VerifyOrder']);

  }

  ngOnInit() {
  }

}

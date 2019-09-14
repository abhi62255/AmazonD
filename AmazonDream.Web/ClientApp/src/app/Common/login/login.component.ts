import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { LoginService } from 'src/app/Services/login.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  constructor(private login: LoginService) { }

  loginF(nf: NgForm) {
    this.login.login(nf.value).subscribe(
      responseData => {
        console.log(responseData)
      }
    );
  }


  ngOnInit() {
  }

}

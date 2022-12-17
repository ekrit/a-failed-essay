import { Component, OnInit } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { MojConfig } from "../moj-config";
import { Router } from "@angular/router";

declare function porukaSuccess(a: string):any;
declare function porukaError(a: string):any;

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  txtLozinka: any;
  txtEmail: any;

  constructor(private router: Router, private httpKlijent: HttpClient) {}

  ngOnInit(): void {}

  gotoRegistracija() {
    this.router.navigate(['/registration']);
  }

  login() {
    let korisnik = {
      email: this.txtEmail,
      lozinka: this.txtLozinka
    };

    this.httpKlijent.post(MojConfig.adresa_servera+ "/Autentifikacija/Login/", korisnik)
      .subscribe((x:any) => {
        if (x!=null) {

          porukaSuccess("uspjesan login");
          localStorage.setItem("autentifikacija-token", x.vrijednost);

          this.router.navigateByUrl("/home");

        }
        else
        {
          localStorage.setItem("autentifikacija-token", "");
          porukaError("neispravan login");
        }
      });

  }

}

import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClient } from "@angular/common/http";
import { MojConfig } from "../moj-config";

declare function porukaSuccess(a: string):any;
declare function porukaError(a: string):any;

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent implements OnInit {

  korisnickoIme: any;
  korisnickoPrezime: any;
  korisnickiEmail: any;
  korisnickaLozinka: any;
  lozinkaponovo: any;


  ngOnInit(): void {
  }

  constructor(private http : HttpClient, private router : Router) {}

  gotoLogin(){
    this.router.navigate(['/login']);
  }

   registruj() {
    let validacijaLozinke = true;
    let validacijaUnosa = true;

    //validacija koja se brine da se lozinke podudaraju
    if (this.korisnickaLozinka != this.lozinkaponovo){
      porukaError("Lozinke se ne podudaraju!")
      validacijaLozinke = false;
    }

    //validacija koja se brine da su svi inputi ispunjeni
    if(this.korisnickaLozinka == "" || this.korisnickiEmail == "" || this.korisnickoIme == "" || this.korisnickoPrezime == "" || this.lozinkaponovo == ""){
      porukaError("Molimo unesite sva potrebna polja!");
      validacijaUnosa = false;
    }

    //ako su validacije ok, dalje se nastavlja sa funkcijom
    if (validacijaLozinke && validacijaUnosa)
    {
      //objekat koji se šalje
      let noviKorisnik = {
        ime : this.korisnickoIme,
        prezime : this.korisnickoPrezime,
        email : this.korisnickiEmail,
        lozinka : this.korisnickaLozinka
      };


      this.http.post('https://localhost:44355/Korisnik/addKorisnik/', noviKorisnik).subscribe(
        (x : any) => {
          if(x == null)
          {
            porukaError("Neuspješno registrovan korisnik!");
          }
          else
          {
            porukaSuccess("Uspješno registrovan korisnik!");
          }

        }
      )

      this.korisnickoIme = "";
      this.korisnickoPrezime = "";
      this.korisnickiEmail = "";
      this.korisnickaLozinka = "";
      this.lozinkaponovo = "";
    }

  }

}

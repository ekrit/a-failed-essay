import {HttpHeaders} from "@angular/common/http";

export class MojConfig{
  static adresa_servera = 'https://localhost:44355';
  static http_opcije= function (){

    let mojtoken = localStorage.getItem("autentifikacija-token");
    return {
        headers: {
        'autentifikacija-token': mojtoken,
      }
    };
  }

}

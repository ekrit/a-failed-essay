import { Component, OnInit } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import {resolveFileWithPostfixes} from "@angular/compiler-cli/ngcc/src/utils";
import {Router} from "@angular/router";


declare function porukaSuccess(a: string) : any;
declare function porukaError(a: string) : any;


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {



  ngOnInit(): void {
  }



}

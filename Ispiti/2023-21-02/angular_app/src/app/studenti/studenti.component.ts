import { Component, OnInit } from '@angular/core';
import {HttpClient, HttpHeaders} from "@angular/common/http";
import {MojConfig} from "../moj-config";
import {Router} from "@angular/router";
declare function porukaSuccess(a: string):any;
declare function porukaError(a: string):any;

@Component({
  selector: 'app-studenti',
  templateUrl: './studenti.component.html',
  styleUrls: ['./studenti.component.css']
})
export class StudentiComponent implements OnInit {

  title:string = 'angularFIT2';
  ime_prezime:string = '';
  opstina: string = '';
  studentPodaci: any;
  filter_ime_prezime: boolean;
  filter_opstina: boolean;


  constructor(private httpKlijent: HttpClient, private router: Router) {
  }

  getStudent() :void
  {
    this.httpKlijent.get(MojConfig.adresa_servera+ "/Student/GetAll", MojConfig.http_opcije()).subscribe(x=>{
      this.studentPodaci = x;
    });
  }

  ngOnInit(): void {
    this.getStudent();
    this.ucitajOpstine();
  }
  ucitajPodatke(){
    if(this.filter_ime_prezime){
      return this.studentPodaci.filter((x:any)=>(x.ime + " " +  x.prezime).startsWith(this.ime_prezime) ||
        (x.prezime + " " +  x.ime).startsWith(this.ime_prezime) && x.isDeleted!=true);
    }
    if(this.filter_opstina){
      return this.studentPodaci.filter((x:any)=>(x.opstina_rodjenja.description).startsWith(this.opstina) && x.isDeleted!=true);
    }
    return this.studentPodaci.filter((x:any)=>x.isDeleted!=true);
  }
  novi_student:any;

  noviStudent() {
    this.novi_student =  {
      id:0,
      ime:this.ime_prezime,
      prezime:'',
      opstina_rodjenja_id:this.zadnjaOpstinaId
    }
  }
  zadnjaOpstinaId:number;
  upisiStudent() {
    this.httpKlijent.post(MojConfig.adresa_servera+"/Student/Snimi", this.novi_student, MojConfig.http_opcije()).subscribe((x:any)=>{
      this.getStudent();
      this.zadnjaOpstinaId = x.opstina_rodjenja_id;
    });
    this.novi_student=null;
    porukaSuccess("Uspjesno dodan novi student!");
  }
  opstinaPodaci:any;
  ucitajOpstine(){
    this.httpKlijent.get(MojConfig.adresa_servera+"/Opstina/GetByAll", MojConfig.http_opcije()).subscribe((x:any)=>{
      this.opstinaPodaci = x;
    });
  }
  odabrani_student:any;
  editStudent() {
    this.httpKlijent.post(MojConfig.adresa_servera+"/Student/Snimi", this.odabrani_student, MojConfig.http_opcije()).subscribe((x:any)=>{
      this.getStudent();
    });
    this.odabrani_student=null;
  }

  otvoriMaticnu(student_paramtar_id:number) {
    this.router.navigate(["student-maticnaknjiga", student_paramtar_id])
  }
}

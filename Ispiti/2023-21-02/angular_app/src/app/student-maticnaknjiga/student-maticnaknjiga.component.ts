import { Component, OnInit } from '@angular/core';
import {ActivatedRoute} from "@angular/router";
import {MojConfig} from "../moj-config";
import {HttpClient} from "@angular/common/http";

declare function porukaSuccess(a: string):any;
declare function porukaError(a: string):any;

@Component({
  selector: 'app-student-maticnaknjiga',
  templateUrl: './student-maticnaknjiga.component.html',
  styleUrls: ['./student-maticnaknjiga.component.css']
})
export class StudentMaticnaknjigaComponent implements OnInit {

  constructor(private httpKlijent: HttpClient, private route: ActivatedRoute) {}
  student_id:any;
  otvoriUpisOvjereno:boolean=false;
  otvoriOvjeru:boolean=false;

  ovjeriLjetni(s:any) {

  }

  upisLjetni(s:any) {

  }

  ovjeriZimski(s:any) {

  }

  ngOnInit(): void {
    this.route.params.subscribe((x:any)=>{
      this.student_id =+ x["student_paramtar_id"]
    });
    this.ucitajOvjerene();
    this.ucitajAkademske();
    this.ucitajStudente();
  }
  ovjereniPodaci:any;
  ucitajOvjerene(){
    this.httpKlijent.get(MojConfig.adresa_servera+"/MaticnaKnjiga/GetAll?student_id=" + this.student_id, MojConfig.http_opcije()).subscribe((x:any)=>{
      this.ovjereniPodaci=x;
    });
    porukaSuccess("Ucitani podaci");
  }
  akademskePodaci:any;
  ucitajAkademske(){
    this.httpKlijent.get(MojConfig.adresa_servera+"/AkademskeGodine/GetAll_ForCmb", MojConfig.http_opcije()).subscribe((x:any)=>{
      this.akademskePodaci=x;
    });
  }
  studentPodaci:any;
  studentIme:string="";
  studentPrezime:string="";
  ucitajStudente(){
    this.httpKlijent.get(MojConfig.adresa_servera+"/Student/GetByID?student_id=" + this.student_id, MojConfig.http_opcije()).subscribe((x:any)=>{
      this.studentPodaci=x;
      this.studentIme=this.studentPodaci.ime;
      this.studentPrezime=this.studentPodaci.prezime;
    });
  }
  DatumUpisa:Date;
  GodinaStudija:number;
  AkademskaGodinaID:number;
  CijenaSkolarine:number;
  ObnovaUpis:boolean;
  Napomena:string="";
  EvidentiraoUpis:string;
  snimiOvjeru() {
    var semestar:upisInfo = {
        datumUpisa:this.DatumUpisa,
      godinaStudija:this.GodinaStudija,
      akademskaGodinaID:this.AkademskaGodinaID,
      cijenaSkolarine:this.CijenaSkolarine,
      obnova:this.ObnovaUpis,
      napomena:this.Napomena,
      evidentiraoUpis:this.EvidentiraoUpis,
      studentID:this.student_id
    }
    this.httpKlijent.post(MojConfig.adresa_servera+"/MaticnaKnjiga/Snimi",semestar, MojConfig.http_opcije()).subscribe((x:any)=>{
      this.ucitajOvjerene();
    });
    porukaSuccess("Snimljena ovjera");
    this.otvoriUpisOvjereno=false;
  }
  IdOvjere:number;
  DatumOvjere:Date;
  NapomenaOvjere:string;
  ovjeriSemestar() {
    var info: ovjeraInfo = {
      id:this.IdOvjere,
      datumOvjere:this.DatumOvjere,
      napomena:this.NapomenaOvjere,
    }
    this.httpKlijent.post(MojConfig.adresa_servera+"/MaticnaKnjiga/Ovjeri", info, MojConfig.http_opcije()).subscribe((x:any)=>{
      this.ucitajOvjerene();
    });
    this.otvoriOvjeru=false
    porukaSuccess("Ovjeren semestar");

  }
}
export interface upisInfo{
  datumUpisa:Date,
  godinaStudija:number,
  akademskaGodinaID:number,
  cijenaSkolarine:number,
  obnova:boolean,
  napomena:string,
  evidentiraoUpis:string,
  studentID:number
}
export interface ovjeraInfo{
  id:number,
  datumOvjere:Date,
  napomena:string,
}

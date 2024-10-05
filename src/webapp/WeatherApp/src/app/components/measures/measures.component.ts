import { Component, Inject, OnInit } from '@angular/core';
import { ApiService } from '../../services/api.service';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { MeasureRequest, MeasureResponse } from '../../models/interfaces/measure';
import { MeasureCardComponent } from '../measure-card/measure-card.component';
import { tmplAstVisitAll } from '@angular/compiler';

@Component({
  selector: 'app-measures',
  standalone: true,
  imports: [FormsModule, CommonModule, MeasureCardComponent],
  templateUrl: './measures.component.html',
  styleUrl: './measures.component.css'
})
export class MeasuresComponent implements OnInit {

  measureBody: MeasureRequest = {
    InitialDate: '',
    FinalDate: ''
  };

  measures: MeasureResponse[] = [];
  measureOnView: MeasureResponse | undefined;
  
  measuresPerPage: number = 8;
  numOfPages: number = 1;
  page: number = 1;
  pagesArray:number[] = [];

  measuresOnPage: MeasureResponse[] = [];

  constructor(private apiService: ApiService) {}
  
  ngOnInit(): void {
    const finalDatePar = new Date();
    const initialDatePar = new Date();
    initialDatePar.setDate(finalDatePar.getDate() - 180);
    this.measureBody.InitialDate = this.formatDate(initialDatePar);
    this.measureBody.FinalDate = this.formatDate(finalDatePar);

    this.load();

  }
  load() {

    const measureBodyParam: MeasureRequest = {
      InitialDate: this.formatDateRequest(this.measureBody.InitialDate),
      FinalDate: this.formatDateRequest(this.measureBody.FinalDate)
    }
    this.apiService.getMeasures(measureBodyParam).subscribe((res: any) => {
      this.measures = res.sort((a: MeasureResponse, b: MeasureResponse) => {
        if (a.ts.date < b.ts.date) return 1;
        if (a.ts.date > b.ts.date) return -1;
        return 0;
      });


      const numOfPagesDouble = this.measures.length / this.measuresPerPage;
      this.numOfPages = Math.floor(numOfPagesDouble);
      if (numOfPagesDouble > this.numOfPages) this.numOfPages += 1;

      this.pagesArray = Array(this.numOfPages).fill(0).map((x,i)=>i + 1);
      this.loadPage(1);
      
    }, (error:any) => {
      alert("Error on request");
    });

  }

  loadPage(page: number) {
    this.measuresOnPage = this.measures.slice((this.measuresPerPage * (page - 1)), (this.measuresPerPage * page));
    this.page = page;
  }

  formatDateRequest(date: string) : string {
    const formattedDate = date.substring(6, 10)+ '-' + date.substring(0,2) + '-' + date.substring(3,5);
    return formattedDate;
  }

  formatDate(date: Date) : string {
    

    const yyyy = date.getFullYear();
    let mm = date.getMonth() + 1; // Months start at 0!
    let dd = date.getDate();
    let ddA = dd.toString();
    let mmA = mm.toString();

    if (dd < 10) ddA = '0' + dd; 
    if (mm < 10) mmA = '0' + mm;

    const formattedDate = mmA + '/' + ddA + '/' + yyyy;
    return formattedDate;
  }

  formatDateString(date: string) : string {
    const dateType = new Date(date);
    const yyyy = dateType.getFullYear();
    let mm = dateType.getMonth() + 1; // Months start at 0!
    let dd = dateType.getDate();
    let ddA = dd.toString();
    let mmA = mm.toString();

    if (dd < 10) ddA = '0' + dd; 
    if (mm < 10) mmA = '0' + mm;

    let hh = dateType.getUTCHours();
    let mi = dateType.getUTCMinutes();
    let ss = dateType.getSeconds();

    let hhA = hh.toString();
    let miA = mi.toString();
    let ssA = ss.toString();

    if (hh < 10) hhA = '0'+ hh;
    if (mi < 10) miA = '0'+ mi;
    if (ss < 10) ssA = '0'+ ss;

    const formattedDate = mmA + '/' + ddA + '/' + yyyy + ' - ' + hhA+':'+miA+':'+ssA;
    return formattedDate;
  }

  onView(measure: MeasureResponse) {
    this.measureOnView = measure;
  }

  onCloseMeasure(event: boolean) {
    this.measureOnView = undefined;
  }
}

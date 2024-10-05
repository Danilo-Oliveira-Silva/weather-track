import { CommonModule } from '@angular/common';
import { Component, EventEmitter, Input, OnInit, Output, Pipe, PipeTransform } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { MeasureResponse } from '../../models/interfaces/measure';
import { BehaviorSubject, ReplaySubject } from 'rxjs';
import { DomSanitizer, SafeResourceUrl } from '@angular/platform-browser';

@Component({
  selector: 'app-measure-card',
  standalone: true,
  imports: [FormsModule, CommonModule],
  templateUrl: './measure-card.component.html',
  styleUrl: './measure-card.component.css'
})



export class MeasureCardComponent implements OnInit {

  urlSafe: SafeResourceUrl = "";

  measureLoaded: MeasureResponse = {
    temperature: 0,
    sId: "",
    preciptation: 0,
    ts: { date: new Date()},
    pressure: 0,
    label: "",
    position: { lat:0, lon:0 }
  };

  @Input() set measure(value: MeasureResponse | undefined) {
    if (value) { 
      this.measureLoaded = value;
      const url = "https://api.mapbox.com/styles/v1/mapbox/satellite-v9/static/"+value.position.lon+","+value.position.lat+",11,0,60/500x480?before_layer=aeroway-line&access_token=<TOKEN_MAPBOX>"
      this.urlSafe = this.sanitizer.bypassSecurityTrustResourceUrl(url);

    }
    else {

    }
  };

  @Output() onCloseMeasure = new EventEmitter<boolean>();
  
  constructor(public sanitizer: DomSanitizer) {
  }
  

  ngOnInit(): void {
    
  }
  
  closeMeasure() {
    this.onCloseMeasure.emit(true);
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

    const formattedDate = mmA + '/' + ddA + '/' + yyyy + ' \n ' + hhA+':'+miA+':'+ssA;
    return formattedDate;


  }


}

import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { LoginResponse } from '../models/interfaces/login';
import { MeasureRequest, MeasureResponse } from '../models/interfaces/measure';
import { RoleResponse } from '../models/interfaces/role';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  constructor(private http: HttpClient) { }

  login(obj: Object): Observable<LoginResponse> {
    return this.http.post<LoginResponse>("auth", obj);
  }

  signup(obj: Object): Observable<LoginResponse> {
    return this.http.post<LoginResponse>("user", obj);
  }

  getRoles(): Observable<RoleResponse> {
    return this.http.get<RoleResponse>("role");
  }

  getMeasures(obj: MeasureRequest) : Observable<MeasureResponse> {
    const tokenObj = JSON.parse(localStorage.getItem('token')!);

    const headers = { 'Authorization': 'Bearer '+tokenObj.token };
    return this.http.get<MeasureResponse>("measure?InitialDate="+obj.InitialDate+"&FinalDate="+obj.FinalDate, { headers });
  }

  
}

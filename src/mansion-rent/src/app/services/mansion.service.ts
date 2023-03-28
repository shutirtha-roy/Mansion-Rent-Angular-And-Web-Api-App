import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { IMansionApiResponse, IMansionResult } from 'src/assets/data/IMansionApiResonse';

@Injectable({
  providedIn: 'root'
})
export class MansionService {
  private baseUrl: string = "/api/v1/VillaAPI/";

  constructor(private http: HttpClient, private router: Router) { }

  addMansion(addMansionRequest: IMansionResult): Observable<IMansionResult> {
    addMansionRequest.id = '00000000-0000-0000-0000-000000000000';
    return this.http.post<IMansionResult>(this.baseUrl, addMansionRequest);
  }

  getAllMansions(): Observable<IMansionApiResponse> {
    return this.http.get<IMansionApiResponse>(this.baseUrl);
  }


}
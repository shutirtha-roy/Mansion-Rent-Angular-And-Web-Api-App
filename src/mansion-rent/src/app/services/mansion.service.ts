import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { IMansionApiResponse } from 'src/assets/data/IMansionApiResonse';

@Injectable({
  providedIn: 'root'
})
export class MansionService {
  private baseUrl: string = "/api/v1/VillaAPI/";

  constructor(private http: HttpClient, private router: Router) { }

  getAllMansions(): Observable<IMansionApiResponse> {
    return this.http.get<IMansionApiResponse>(this.baseUrl);
  }
}
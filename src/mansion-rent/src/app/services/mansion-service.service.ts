import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class MansionServiceService {
  private baseUrl: string = "/api/v1/VillaAPI/";

  constructor(private http: HttpClient, private router: Router) { }

  getAllMansions(): Observable<any[]> {
    return this.http.get<any[]>(this.baseUrl);
  }
}
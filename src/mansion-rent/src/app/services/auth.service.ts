import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { IApiResponse } from 'src/assets/data/IApiResponse';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private baseUrl: string = "/api/v1/Auth/";

  constructor(private http: HttpClient, private router: Router) { }

  signUp(userObj: any) {
    return this.http.post<IApiResponse>(`${this.baseUrl}register`, userObj);
  }

  login(loginObj: any) {
    return this.http.post<IApiResponse>(`${this.baseUrl}login`, loginObj);
  }

  signOut() {
    localStorage.clear();
    this.router.navigate(['auth/login']);
  }

  storeToken(tokenValue: string) {
    localStorage.setItem('token', tokenValue);
  }

  getToken() {
    return localStorage.getItem('token');
  }

  isLoggedIn(): boolean {
    return !!localStorage.getItem('token');
  }

  storeName(name: string) {
    localStorage.setItem('name', name);
  }

  getName() {
    return localStorage.getItem('name');
  }
}
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { baseUrl } from 'src/environments/environments';
import { Login } from 'src/app/models/account.model';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root',
})
export class AccountService {
  constructor(
    private httpClient: HttpClient,
    private router: Router) {}

  login(login: Login): void {
    const successCallback = (response: any) => {
      const token = response.token;
      if(token) {
        localStorage.setItem('token', token);
        this.router.navigateByUrl('/page/message')
      }
    };

    const errorCallback = (error: any) => console.log(error);
    const url = `/api/Account/Login`;
    this.httpClient.post<any>(url, login).subscribe({
      next: (response) => successCallback(response),
      error: (error) => errorCallback(error)
    });
  }
}

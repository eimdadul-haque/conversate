import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Login } from 'src/app/models/account.model';
import { baseUrl } from 'src/environments/environments';

@Injectable({
  providedIn: 'root',
})
export class AccountService {
  constructor(private httpClient: HttpClient) {}

  login(login: Login): void {
    
    const successCallback = (response: any) => {
      const token = response;
      if(token) {
        localStorage.setItem('token', token);
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

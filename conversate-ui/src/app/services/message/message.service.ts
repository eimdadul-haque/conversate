import { Injectable } from '@angular/core';
import * as signalR from '@microsoft/signalr';
import { HubConnection, HubConnectionBuilder } from '@microsoft/signalr';
import { BehaviorSubject, Observable, Subject } from 'rxjs';
import { Message } from 'src/app/models/message.model';
import { baseUrl } from 'src/environments/environments';

@Injectable({
  providedIn: 'root',
})
export class MessageService {
  hubConnection: HubConnection;
  messageSubject$ = new BehaviorSubject<Message>({} as Message);

  constructor() {
    this.startConnection();
  }

  getToken(): string {
    const token = localStorage.getItem('token');
    if (token) {
      return token;
    } else {
      throw new Error('token not found!');
    }
  }

  startConnection(): void {
    const token = this.getToken();
    this.hubConnection = new HubConnectionBuilder()
      .withUrl(baseUrl + '/message', {
        skipNegotiation: true,
        transport: signalR.HttpTransportType.WebSockets,
        accessTokenFactory: () => token,
      })
      .configureLogging(signalR.LogLevel.Information)
      .build();

    this.hubConnection.start().catch((err) => console.log(err));

    this.hubConnection.on('ReceiveMessage', (message) => {
      this.setMessage(message);
    });
  }

  sendMessage(message: Message): void {
    this.hubConnection
      .invoke('SendMessageToAll', message)
      .catch((error) => console.log(error));
  }

  setMessage(message: Message): void {
    this.messageSubject$.next(message);
  }

  getMessage(): Observable<Message> {
    return this.messageSubject$.asObservable();
  }
}

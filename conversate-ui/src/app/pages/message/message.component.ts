import { AfterViewInit, Component, ElementRef, OnInit, ViewChild } from '@angular/core';

@Component({
  selector: 'app-message',
  templateUrl: './message.component.html',
  styleUrls: ['./message.component.scss']
})
export class MessageComponent implements AfterViewInit {
  messages: any[] = [
    { text: 'Hello!', isSent: false },
    { text: 'Hi there!', isSent: true },
  ];

  activeUsers: any[] = [
    { name: 'John Doe' },
    { name: 'Jane Smith' },
    { name: 'Samuel Johnson' },
  ];

  newMessage = '';

  @ViewChild('chatMessages') chatMessages!: ElementRef;

  constructor() {}

  ngAfterViewInit(): void {
    this.scrollToBottom();
  }

  sendMessage(): void {
    if (this.newMessage.trim() !== '') {
      this.messages.push({ text: this.newMessage, isSent: false });
      this.newMessage = '';
      this.scrollToBottom();
    }
  }

  private scrollToBottom(): void {
    if (this.chatMessages) {
      this.chatMessages.nativeElement.scrollTop = this.chatMessages.nativeElement.scrollHeight;
    }
  }
}
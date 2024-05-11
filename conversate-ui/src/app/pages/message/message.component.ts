import {
  AfterViewInit,
  Component,
  ElementRef,
  OnInit,
  ViewChild,
} from '@angular/core';
import { Message } from 'src/app/models/message.model';
import { User } from 'src/app/models/user.model';
import { MessageService } from 'src/app/services/message/message.service';

@Component({
  selector: 'app-message',
  templateUrl: './message.component.html',
  styleUrls: ['./message.component.scss'],
})
export class MessageComponent implements OnInit, AfterViewInit {
  user: User = {
    id: 'user-00101',
    userName: 'Eimdadul',
    email: 'eimdadulhaque@gmail.com',
  } as User;

  messages: Message[] = [];
  message: Message = {} as Message;
  selecedUser: User = {} as User;

  activeUsers: any[] = [
    { name: 'John Doe' },
    { name: 'Jane Smith' },
    { name: 'Samuel Johnson' },
  ];

  @ViewChild('chatMessages') chatMessages!: ElementRef;

  constructor(private messageService: MessageService) {}

  ngOnInit(): void {
    this.messageService.getMessage().subscribe((msg) => {
      if (this.isEmptyObject(msg)) {
        this.messages.push(msg);
      }
    });
  }

  ngAfterViewInit(): void {
    this.scrollToBottom();
  }

  sendMessage(): void {
    if (this.message.content.trim() !== '') {
      this.message.senderUserId = this.user.id;
      this.messageService.sendMessage(this.message);
      this.scrollToBottom();
      this.message = {} as Message;
    }
  }

  private scrollToBottom(): void {
    if (this.chatMessages) {
      this.chatMessages.nativeElement.scrollTop =
        this.chatMessages.nativeElement.scrollHeight;
    }
  }

  isEmptyObject(object: any): boolean {
    return Object.entries(object).length > 0;
  }
}

import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { PagesRoutingModule } from './pages-routing.module';
import { MessageComponent } from './message/message.component';
import { FormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    MessageComponent
  ],
  imports: [
    FormsModule,
    CommonModule,
    PagesRoutingModule
  ]
})
export class PagesModule { }

import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { HttpClientModule } from '@angular/common/http';

import { MatProgressBarModule } from '@angular/material/progress-bar';

import { ToastrModule } from "ngx-toastr";

// Services
import { QuestionsService, TestService } from './services';

// Components
import { MainComponent, MyTestsComponent, TestsComponent, TopNavComponent, TakeTestComponent, TestResultComponent } from './components';

@NgModule({
  declarations: [
    AppComponent,

    // Components
    TopNavComponent,
    MainComponent,
    MyTestsComponent,
    TestsComponent,
    TestResultComponent,
    TakeTestComponent
  ],
  imports: [
    CommonModule,
    BrowserModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    ToastrModule.forRoot({
      positionClass: 'toast-bottom-right'
    }),
    MatProgressBarModule
  ],
  providers: [
    QuestionsService,
    TestService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }

import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { TakenTest } from 'src/app/dtos/taken-test';
import { TestService } from 'src/app/services';

@Component({
  selector: 'app-my-tests',
  templateUrl: 'my-tests.component.html',
  styleUrls: ['my-tests.component.scss']
})

export class MyTestsComponent implements OnInit {
  public takenTests$: Observable<TakenTest[]>;
  constructor(
    private testService: TestService,
    private router: Router) {}

  ngOnInit() {
    this.takenTests$ = this.testService.getTakenTests();
  }
}

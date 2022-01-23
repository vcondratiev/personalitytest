import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { QuestionSet } from 'src/app/models';
import { QuestionsService } from 'src/app/services';

@Component({
  selector: 'app-tests',
  templateUrl: 'tests.component.html',
  styleUrls: ['tests.component.scss']
})

export class TestsComponent implements OnInit {
  public questionSets$: Observable<QuestionSet[]>;

  constructor(
    private questionsService: QuestionsService,
    private router: Router) {}

  ngOnInit() {
    this.questionSets$ = this.questionsService.getAll();
  }

  public takeTest(id: string): void {
    this.router.navigate(['/take-test', id]);
  }
}

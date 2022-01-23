import { ThrowStmt } from '@angular/compiler';
import { Component, HostListener, OnInit } from '@angular/core';
import { Form, FormArray, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { SaveTest } from 'src/app/dtos';
import { QuestionSet } from 'src/app/models';
import { QuestionsService, TestService } from 'src/app/services';

@Component({
  selector: 'app-take-test',
  templateUrl: 'take-test.component.html',
  styleUrls: ['take-test.component.scss']
})

export class TakeTestComponent implements OnInit {
  public test: QuestionSet;
  public testForm: FormGroup;
  public activeQuestionGroup: FormGroup;

  public activeQuestionIndex = 0;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private questionsService: QuestionsService,
    private testService: TestService,
    private toastr: ToastrService,
    private fb: FormBuilder) {
    this.testForm = this.fb.group({
      testId: ['', [Validators.required]],
      name: ['', Validators.required],
      description: ['', Validators.required],
      questions: this.fb.array([])
    });

    this.route.params.subscribe(params => {
      if (params.id) {
        this.loadTest(params.id);
      }
    });
  }

  ngOnInit() { }

  @HostListener('window:keyup', ['$event'])
  public keyup(event: KeyboardEvent): void {
    switch (event.key) {
      case 'Enter':
        {
          event.stopPropagation();
          event.preventDefault();
          if (this.activeQuestionGroup.valid) {
            this.nextQuestion();
          }
        }
        break;
      case 'Backspace':
        {
          event.stopPropagation();
          event.preventDefault();
          this.previousQuestion();
        }
        break;
    }
  }

  public get options() {
    return (this.activeQuestionGroup.get('options') as FormArray).controls as FormGroup[];
  }

  public getSelectedOption() {
    return this.activeQuestionGroup.get('selectedOption') as FormControl;
  }

  public loadTest(id: string): void {
    this.questionsService.get(id).subscribe(result => {
      if (result) {
        this.test = result;
        this.testForm.patchValue({
          testId: id,
          name: result.name,
          description: result.description
        });

        this.test.questions.forEach(q => {
          (this.testForm.get('questions') as FormArray).push(this.fb.group({
            id: q.id,
            name: q.title,
            options: this.fb.array(q.questionOptions.map(o => this.fb.group({
              id: [o.id, Validators.required],
              name: [o.text, Validators.required],
              value: [o.value, Validators.required]
            }))),
            selectedOption: ['', Validators.required]
          }))
        });

        this.testForm.updateValueAndValidity();

        let first = (this.testForm.get('questions') as FormArray).at(this.activeQuestionIndex) as FormGroup;
        this.activeQuestionGroup = first;
        this.activeQuestionGroup.updateValueAndValidity();
      }
      else {
        this.toastr.error('Could not load test. Please try again later.');
        this.router.navigate(['/tests']);
      }
    })
  }

  public previousQuestion(): void {
    if (this.activeQuestionIndex > 0) {
      this.activeQuestionIndex--;
      this.activeQuestionGroup = (this.testForm.get('questions') as FormArray).at(this.activeQuestionIndex) as FormGroup;
    }
  }

  public nextQuestion(): void {
    if (this.activeQuestionIndex < this.test.questions.length - 1) {
      this.activeQuestionIndex++;
      this.activeQuestionGroup = (this.testForm.get('questions') as FormArray).at(this.activeQuestionIndex) as FormGroup;
    }
  }

  public finish(): void {
    let answers = this.testForm.value.questions.map((q: any) => ({ questionId: q.id, value: q.selectedOption }));

    let result = {
      questionSetId: this.testForm.value.testId,
      answers: answers
    }

    this.testService.save(result).subscribe(result => {
      if(result) {
        this.router.navigate(['/test-results', result.identifier])
      }
    })
  }

  public submit(e: any): void {
    e.preventDefault();
    e.stopPropagation();
    return;
  }
}

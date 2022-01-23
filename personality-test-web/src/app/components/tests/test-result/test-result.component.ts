import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { TestResults } from 'src/app/dtos';
import { TakenTest } from 'src/app/dtos/taken-test';
import { TestService } from 'src/app/services';

@Component({
  selector: 'app-test-result',
  templateUrl: 'test-result.component.html',
  styleUrls: ['test-result.component.scss']
})

export class TestResultComponent implements OnInit {
  public results: TakenTest;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private testService: TestService) {
      this.route.params.subscribe(params => {
        if (params.id) {
          this.loadResults(params.id);
        }
        else {
          this.router.navigate(['/tests']);
        }
      });
    }

  ngOnInit() {

  }
  private loadResults(id: string): void {
    this.testService.getResults(id).subscribe(result => {
      this.results = result;
    });
  }
}

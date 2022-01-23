import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-main',
  templateUrl: 'main.component.html',
  styleUrls: ['main.component.scss']
})

export class MainComponent implements OnInit {
  constructor(private router: Router) { }

  ngOnInit() { }

  public takePersonalityTest(): void {
    this.router.navigate(['/take-test', '384eebbc-0516-4233-91f8-dbcee11c0f3e']);
  }
}

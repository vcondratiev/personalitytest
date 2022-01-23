import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MainComponent, MyTestsComponent, TakeTestComponent, TestResultComponent, TestsComponent } from './components';

const routes: Routes = [
  { path: '', component: MainComponent },
  { path: 'tests', component: TestsComponent },
  { path: 'taken', component: MyTestsComponent },
  { path: 'take-test/:id', component: TakeTestComponent },
  { path: 'test-results/:id', component: TestResultComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

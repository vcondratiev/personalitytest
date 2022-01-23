import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Question } from '../models/questions';

import { environment as env } from '../../environments/environment';
import { QuestionSet } from '../models/question-set';
import { AddQuestionSetDto } from '../dtos/add-question-set';
import { Test } from '../models/test';
import { SaveTest, TestResults } from '../dtos';
import { TakenTest } from '../dtos/taken-test';

@Injectable({providedIn: 'root'})
export class TestService {
    constructor(private http: HttpClient) { }

    public getTakenTests(): Observable<TakenTest[]> {
      return this.http.get<TakenTest[]>(`${env.apiUrl}/tests`);
    }

    public load(id: string): Observable<Test> {
      return this.http.get<Test>(`${env.apiUrl}/tests/${id}`);
    }

    public getResults(id: string): Observable<TakenTest> {
      return this.http.get<TakenTest>(`${env.apiUrl}/tests/${id}/result`);
    }

    public save(test: SaveTest): Observable<any> {
      return this.http.post<any>(`${env.apiUrl}/tests/`, test);
    }
}

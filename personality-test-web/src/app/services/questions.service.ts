import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Question } from '../models/questions';

import { environment as env } from '../../environments/environment';
import { QuestionSet } from '../models/question-set';
import { AddQuestionSetDto } from '../dtos/add-question-set';

@Injectable({providedIn: 'root'})
export class QuestionsService {
    constructor(private http: HttpClient) { }

    public getAll(): Observable<QuestionSet[]> {
      return this.http.get<QuestionSet[]>(`${env.apiUrl}/questions/`);
    }

    public get(id: string): Observable<QuestionSet> {
      return this.http.get<QuestionSet>(`${env.apiUrl}/questions/${id}`);
    }

    public create(question: AddQuestionSetDto): Observable<string> {
      return this.http.post<string>(`${env.apiUrl}/questions/`, question);
    }

    public update(question: AddQuestionSetDto): Observable<string> {
      return this.http.put<string>(`${env.apiUrl}/questions/`, question);
    }

    public delete(id: string): Observable<boolean> {
      return this.http.delete<boolean>(`${env.apiUrl}/questions/${id}`);
    }
}

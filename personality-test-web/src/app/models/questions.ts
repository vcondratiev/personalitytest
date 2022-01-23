import { QuestionType } from "./enums/question-type";
import { QuestionAnswer } from "./question-answer";
import { QuestionOption } from "./question-option";

export class Question {
  id: string;
  title: string;
  order: number;
  questionType: QuestionType;

  questionOptions: QuestionOption[];
  answers: QuestionAnswer[];
}

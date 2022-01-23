import { Question } from "./questions";
import { Test } from "./test";

export class QuestionAnswer {
  id: string;
  questionId: string;
  question: Question;
  value: string;

  testId: string;
  test: Test;
}

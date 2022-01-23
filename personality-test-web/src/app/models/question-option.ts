import { Question } from "./questions";

export class QuestionOption {
  id: string;
  text: string;
  value: string;

  questionId: string
  question: Question;
}

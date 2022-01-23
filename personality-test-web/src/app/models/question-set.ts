import { Question } from "./questions";

export class QuestionSet {
  id: string;
  name: string;
  description: string;
  order: number;

  questions: Question[];
}

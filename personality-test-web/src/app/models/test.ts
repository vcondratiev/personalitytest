import { QuestionAnswer } from "./question-answer";
import { QuestionSet } from "./question-set";

export class Test {
  id: string;
  createdAt: Date;
  identifier: string;
  questionSetId: string;
  questionSet: QuestionSet;

  answers: QuestionAnswer[];
}

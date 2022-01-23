import { AddQuestionOptionDto } from "./add-question-option";

export class AddQuestionDto {
  title: string;
  order: number;

  questionOptions: AddQuestionOptionDto[];
}

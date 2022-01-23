import { AddQuestionDto } from "./add-question";

export class AddQuestionSetDto {
  title: string;
  description: string;
  order: number;

  question: AddQuestionDto[];
}

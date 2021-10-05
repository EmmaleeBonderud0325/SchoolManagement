import { Injectable } from '@angular/core';

@Injectable()
export class BasicEssayQuestionAnswerModel{
  id:number;
  questionId :number ;
  questionName :string ;
  answerText:string;
  modifiedOn :Date;
  createdOn  :Date;
}
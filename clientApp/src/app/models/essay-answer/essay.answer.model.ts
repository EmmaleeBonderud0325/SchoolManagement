import { Injectable } from '@angular/core';

@Injectable()
export class EssayQuestionAnswerModel{
  id:number;
  questionId :number ;
  answerText:string;
  modifiedOn :Date;
  createdOn  :Date;
}
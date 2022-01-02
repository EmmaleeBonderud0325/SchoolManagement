import { McqQuestionStudentAnswerModel } from './mcq-question-student-answer.model';
import { PaginatedItemsModel } from './../common/paginated.Items.model';
import { Injectable } from '@angular/core';
@Injectable()

export class MCQQuestionStudentAnswerPaginatedItemsViewModel extends PaginatedItemsModel
{
    data:McqQuestionStudentAnswerModel[];
}

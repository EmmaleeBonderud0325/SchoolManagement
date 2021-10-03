import { BasicMCQQuestionAnswerModel } from './basic.mcqquestionanswer.model';
import { PaginatedItemsModel } from './../common/paginated.Items.model';
import { Injectable } from '@angular/core';
@Injectable()

export class MCQQuestionAnswerPaginatedItemsViewModel extends PaginatedItemsModel
{
    data:BasicMCQQuestionAnswerModel[];
}

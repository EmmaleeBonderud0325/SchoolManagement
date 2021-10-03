import { BasicQuestionModel } from './basic.question.model';
import { PaginatedItemsModel } from './../common/paginated.Items.model';
import { Injectable } from '@angular/core';
@Injectable()

export class QuestionPaginatedItemsViewModel extends PaginatedItemsModel
{
    data:BasicQuestionModel[];
}

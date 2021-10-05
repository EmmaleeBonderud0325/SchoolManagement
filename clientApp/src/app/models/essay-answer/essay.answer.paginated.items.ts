import { Injectable } from "@angular/core";
import { BasicEssayQuestionAnswerModel } from "./basic.essay.answer.model";
import { PaginatedItemsModel } from './../common/paginated.Items.model';

@Injectable()

export class EssayAnswerPaginatedItemsViewModel extends PaginatedItemsModel
{
    data:BasicEssayQuestionAnswerModel[];
}
 
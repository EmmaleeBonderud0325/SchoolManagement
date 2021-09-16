import { BasicLessonModel } from './basic.class.model';
import { PaginatedItemsModel } from './../common/paginated.Items.model';
import { Injectable } from '@angular/core';
@Injectable()

export class LessonPaginatedItemsViewModel extends PaginatedItemsModel
{
    data:BasicLessonModel[];
}

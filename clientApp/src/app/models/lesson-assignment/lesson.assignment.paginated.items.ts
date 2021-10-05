
import { PaginatedItemsModel } from './../common/paginated.Items.model';
import { Injectable } from '@angular/core';
import { BasicLessonAssignmentModel } from './basic.lesson.assignment.model';


@Injectable()

export class LessonAssignmentPaginatedItemsViewModel extends PaginatedItemsModel
{
    data:BasicLessonAssignmentModel[];
}
 
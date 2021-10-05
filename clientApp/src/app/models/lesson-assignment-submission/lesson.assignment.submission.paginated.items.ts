
import { PaginatedItemsModel } from './../common/paginated.Items.model';
import { Injectable } from '@angular/core';
import { BasicLessonAssignmentSubmissionModel } from './basic.lesson.assignment.submission.model';



@Injectable()

export class LessonAssignmentSubmissionPaginatedItemsViewModel extends PaginatedItemsModel
{
    data:BasicLessonAssignmentSubmissionModel[];
}
 
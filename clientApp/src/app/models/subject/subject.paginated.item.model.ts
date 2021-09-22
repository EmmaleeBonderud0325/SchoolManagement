import { BasicSubjectModel } from './basic.subject.model';
import { PaginatedItemsModel } from './../common/paginated.Items.model';
import { Injectable } from '@angular/core';

@Injectable()
export class SubjectPaginatedItemViewModel extends PaginatedItemsModel
{
    data:BasicSubjectModel[];
}
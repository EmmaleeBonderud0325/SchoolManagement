import { BasicHeadOfDepartmentModel } from './basic.head.of.department.model';
import { PaginatedItemsModel } from './../common/paginated.Items.model';
import { Injectable } from '@angular/core';

@Injectable()
export class HeadOfDepartmentPaginatedItemViewModel extends PaginatedItemsModel
{
    data:BasicHeadOfDepartmentModel[];
}
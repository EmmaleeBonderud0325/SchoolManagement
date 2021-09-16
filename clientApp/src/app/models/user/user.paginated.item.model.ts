import { BasicUserModel } from './basic.user.model';
import { PaginatedItemsModel } from './../common/paginated.Items.model';
import { Injectable } from '@angular/core';

@Injectable()
export class UserPaginatedItemViewModel extends PaginatedItemsModel
{
    data:BasicUserModel[];
}
import { Injectable } from '@angular/core';

@Injectable()
export class PaginatedItemsModel {
    currentPage: number;
    pageSize: number;
    totalPageCount: number;
    totalRecordCount: number;
}
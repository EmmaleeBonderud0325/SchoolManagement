import { Injectable } from '@angular/core';
import { ClassSubjectTeacherModel } from "./class.subject.teacher.model";
import { PaginatedItemsModel } from "../common/paginated.Items.model";
import { BasicClassModel } from "../../models/class/basic.class.model";

@Injectable()
export class ClassPaginatedItemsViewModel extends PaginatedItemsModel {
    data: BasicClassModel[];
}
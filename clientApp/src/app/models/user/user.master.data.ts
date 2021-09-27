import { DropDownModel } from './../common/drop-down.model';
import { Injectable } from '@angular/core';

@Injectable()
export class UserMasterDataModel
{
    userRoles:DropDownModel[];
    academicLevels:DropDownModel[];
}
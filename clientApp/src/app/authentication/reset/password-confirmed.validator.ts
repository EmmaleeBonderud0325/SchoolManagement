import { FormGroup } from '@angular/forms';
export function confirmedPasswordValidator(controlName: string, matchingControlName: string)
{
    return(fg:FormGroup)=>
    {
        const control = fg.controls[controlName];
        const matchingControl = fg.controls[matchingControlName];

        if(matchingControl.errors && ! matchingControl.errors.confirmedValidator)
        {
            return;
        }
        if(control.value !== matchingControl.value)
        {
            matchingControl.setErrors({ confirmedValidator: true });
        }
        else
        {
            matchingControl.setErrors(null);
        }
    }
}
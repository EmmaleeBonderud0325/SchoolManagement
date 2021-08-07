import { NgModule } from '@angular/core';

import { FeatherModule } from 'angular-feather';
import { allIcons } from 'angular-feather/icons';

// Select some icons (use an object, not an array)

@NgModule({
  imports: [FeatherModule.pick(allIcons)],
  exports: [FeatherModule],
})
export class IconsModule {}

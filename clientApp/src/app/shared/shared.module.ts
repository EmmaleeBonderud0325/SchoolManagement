import { BootstrapModule } from './bootstrap.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { IconsModule } from './feather-icons.module';
import { NgxSpinnerModule } from 'ngx-spinner';

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule,
    NgxSpinnerModule,
    IconsModule,
    BootstrapModule,
  ],
  exports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule,
    NgxSpinnerModule,
    IconsModule,
    BootstrapModule,
  ],
})
export class SharedModule {}

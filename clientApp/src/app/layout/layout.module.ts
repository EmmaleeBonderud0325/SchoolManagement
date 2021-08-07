import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AuthLayoutComponent } from './app-layout/auth-layout/auth-layout.component';
import { MainLayoutComponent } from './app-layout/main-layout/main-layout.component';
import { FooterComponent } from './footer/footer.component';
@NgModule({
  imports: [CommonModule],
  declarations: [AuthLayoutComponent, MainLayoutComponent, FooterComponent],
})
export class LayoutModule {}

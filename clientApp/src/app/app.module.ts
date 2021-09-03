import { NgxDatatableModule } from '@swimlane/ngx-datatable';
import { BrowserModule } from '@angular/platform-browser';
import { CoreModule } from './core/core.module';
import { SharedModule } from './shared/shared.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ReactiveFormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './layout/header/header.component';
import { PageLoaderComponent } from './layout/page-loader/page-loader.component';
import { SidebarComponent } from './layout/sidebar/sidebar.component';
import { RightSidebarComponent } from './layout/right-sidebar/right-sidebar.component';
import { AuthLayoutComponent } from './layout/app-layout/auth-layout/auth-layout.component';
import { MainLayoutComponent } from './layout/app-layout/main-layout/main-layout.component';
import { FooterComponent } from './layout/footer/footer.component';
import { LocationStrategy, HashLocationStrategy } from '@angular/common';
import { fakeBackendProvider } from './core/interceptor/fake-backend';
import { ErrorInterceptor } from './core/interceptor/error.interceptor';
import { JwtInterceptor } from './core/interceptor/jwt.interceptor';
import {
  PerfectScrollbarModule,
  PERFECT_SCROLLBAR_CONFIG,
  PerfectScrollbarConfigInterface,
} from 'ngx-perfect-scrollbar';

import { TranslateModule, TranslateLoader } from '@ngx-translate/core';
import { TranslateHttpLoader } from '@ngx-translate/http-loader';

import {
  HttpClientModule,
  HTTP_INTERCEPTORS,
  HttpClient,
} from '@angular/common/http';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { AuthGuard } from './core/guard/auth.guard';
import { NgModule } from '@angular/core';


const DEFAULT_PERFECT_SCROLLBAR_CONFIG: PerfectScrollbarConfigInterface = {
  suppressScrollX: true,
  wheelPropagation: false,
};

export function createTranslateLoader(http: HttpClient): any {
  return new TranslateHttpLoader(http, 'assets/i18n/', '.json');
}

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    PageLoaderComponent,
    SidebarComponent,
    RightSidebarComponent,
    AuthLayoutComponent,
    MainLayoutComponent,
    FooterComponent,
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    HttpClientModule,
    NgxDatatableModule,
    ReactiveFormsModule,
    PerfectScrollbarModule,
    NgxDatatableModule,
    TranslateModule.forRoot({
      loader: {
        provide: TranslateLoader,
        useFactory: createTranslateLoader,
        deps: [HttpClient],
      },
    }),
    // core & shared
    CoreModule,
    SharedModule,
    NgbModule,
  ],
  providers: [
    { provide: LocationStrategy, useClass: HashLocationStrategy },
    {
      provide: PERFECT_SCROLLBAR_CONFIG,
      useValue: DEFAULT_PERFECT_SCROLLBAR_CONFIG,
    },
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true },
  AuthGuard],
  bootstrap: [
      AppComponent
  
  ],
  entryComponents: []
})
export class AppModule {}

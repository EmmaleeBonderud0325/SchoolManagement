import { Component } from '@angular/core';
import { Event, Router, NavigationStart, NavigationEnd } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { PlatformLocation } from '@angular/common';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent {
  currentUrl: string;
  constructor(
    public _router: Router,
    location: PlatformLocation,
    private spinner: NgxSpinnerService
  ) {
    this._router.events.subscribe((routerEvent: Event) => {
      if (routerEvent instanceof NavigationStart) {
        this.spinner.show();
        location.onPopState(() => {
          window.location.reload();
        });
        this.currentUrl = routerEvent.url.substring(
          routerEvent.url.lastIndexOf('/') + 1
        );
      }
      if (routerEvent instanceof NavigationEnd) {
        this.spinner.hide();
      }
      window.scrollTo(0, 0);
    });
  }
}

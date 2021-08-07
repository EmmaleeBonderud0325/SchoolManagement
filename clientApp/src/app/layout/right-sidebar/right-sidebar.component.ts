import { DOCUMENT } from '@angular/common';
import {
  Component,
  Inject,
  ElementRef,
  OnInit,
  AfterViewInit,
  Renderer2,
  HostListener,
  ChangeDetectionStrategy,
} from '@angular/core';

import { RightSidebarService } from 'src/app/core/service/rightsidebar.service';
import { ConfigService } from '../../config/config.service';

@Component({
  changeDetection: ChangeDetectionStrategy.OnPush,
  selector: 'app-right-sidebar',
  templateUrl: './right-sidebar.component.html',
  styleUrls: ['./right-sidebar.component.sass'],
})
export class RightSidebarComponent implements OnInit, AfterViewInit {
  selectedBgColor = 'white';
  maxHeight: string;
  maxWidth: string;
  showpanel = false;
  isOpenSidebar: boolean;
  isDarkSidebar = false;
  isDarTheme = false;
  headerHeight = 60;
  public config: any = {};

  constructor(
    @Inject(DOCUMENT) private document: Document,
    private renderer: Renderer2,
    public elementRef: ElementRef,
    private rightSidebarService: RightSidebarService,
    private configService: ConfigService
  ) {}
  ngOnInit() {
    this.config = this.configService.configData;
    this.rightSidebarService.sidebarState.subscribe((isRunning) => {
      this.isOpenSidebar = isRunning;
    });
    this.setMenuHeight();
  }

  ngAfterViewInit() {
    // set header color on startup
    if (localStorage.getItem('choose_skin')) {
      this.renderer.addClass(
        this.document.body,
        localStorage.getItem('choose_skin')
      );
      this.selectedBgColor = localStorage.getItem('choose_skin_active');
    } else {
      this.renderer.addClass(
        this.document.body,
        'theme-' + this.config.layout.theme_color
      );
      this.selectedBgColor = this.config.layout.theme_color;
    }

    if (localStorage.getItem('menuOption')) {
      if (localStorage.getItem('menuOption') === 'dark-sidebar') {
        this.isDarkSidebar = true;
      } else if (localStorage.getItem('menuOption') === 'light-sidebar') {
        this.isDarkSidebar = false;
      } else {
        this.isDarkSidebar =
          this.config.layout.sidebar.backgroundColor === 'dark' ? true : false;
      }
    } else {
      this.isDarkSidebar =
        this.config.layout.sidebar.backgroundColor === 'dark' ? true : false;
    }

    if (localStorage.getItem('theme')) {
      if (localStorage.getItem('theme') === 'dark') {
        this.isDarTheme = true;
      } else if (localStorage.getItem('theme') === 'light') {
        this.isDarTheme = false;
      } else {
        this.isDarTheme = this.config.layout.variant === 'dark' ? true : false;
      }
    } else {
      this.isDarTheme = this.config.layout.variant === 'dark' ? true : false;
    }
  }
  @HostListener('window:resize', ['$event'])
  windowResizecall(event) {
    this.setMenuHeight();
  }
  setMenuHeight() {
    const height = window.innerHeight - this.headerHeight;
    this.maxHeight = height + '';
  }

  selectTheme(e) {
    this.selectedBgColor = e;
    const prevTheme = this.elementRef.nativeElement
      .querySelector('.choose-theme li.active')
      .getAttribute('data-theme');
    this.renderer.removeClass(this.document.body, 'theme-' + prevTheme);
    this.renderer.addClass(this.document.body, 'theme-' + this.selectedBgColor);
    localStorage.setItem('choose_skin', 'theme-' + this.selectedBgColor);
    localStorage.setItem('choose_skin_active', this.selectedBgColor);
  }
  lightSidebarBtnClick() {
    this.renderer.removeClass(this.document.body, 'dark-sidebar');
    this.renderer.addClass(this.document.body, 'light-sidebar');
    const menuOption = 'light-sidebar';
    localStorage.setItem('menuOption', menuOption);
  }
  darkSidebarBtnClick() {
    this.renderer.removeClass(this.document.body, 'light-sidebar');
    this.renderer.addClass(this.document.body, 'dark-sidebar');
    const menuOption = 'dark-sidebar';
    localStorage.setItem('menuOption', menuOption);
  }
  lightThemeBtnClick() {
    this.renderer.removeClass(this.document.body, 'dark');
    this.renderer.removeClass(this.document.body, 'dark-sidebar');

    if (localStorage.getItem('choose_skin')) {
      this.renderer.removeClass(
        this.document.body,
        localStorage.getItem('choose_skin')
      );
    } else {
      this.renderer.removeClass(
        this.document.body,
        'theme-' + this.config.layout.theme_color
      );
    }

    this.renderer.addClass(this.document.body, 'light');
    this.renderer.addClass(this.document.body, 'light-sidebar');
    this.renderer.addClass(this.document.body, 'theme-white');
    const theme = 'light';
    const menuOption = 'light-sidebar';
    this.selectedBgColor = 'white';
    this.isDarkSidebar = false;
    localStorage.setItem('choose_skin', 'theme-white');
    localStorage.setItem('theme', theme);
    localStorage.setItem('menuOption', menuOption);
  }
  darkThemeBtnClick() {
    this.renderer.removeClass(this.document.body, 'light');
    this.renderer.removeClass(this.document.body, 'light-sidebar');

    if (localStorage.getItem('choose_skin')) {
      this.renderer.removeClass(
        this.document.body,
        localStorage.getItem('choose_skin')
      );
    } else {
      this.renderer.removeClass(
        this.document.body,
        'theme-' + this.config.layout.theme_color
      );
    }

    this.renderer.addClass(this.document.body, 'dark');
    this.renderer.addClass(this.document.body, 'dark-sidebar');
    this.renderer.addClass(this.document.body, 'theme-black');
    const theme = 'dark';
    const menuOption = 'dark-sidebar';
    this.selectedBgColor = 'black';
    this.isDarkSidebar = true;
    localStorage.setItem('choose_skin', 'theme-black');
    localStorage.setItem('theme', theme);
    localStorage.setItem('menuOption', menuOption);
  }
  toggleRightSidebar(): void {
    this.rightSidebarService.setRightSidebar(
      (this.isOpenSidebar = !this.isOpenSidebar)
    );
  }
}

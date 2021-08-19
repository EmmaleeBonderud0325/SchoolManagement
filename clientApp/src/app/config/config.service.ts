import { Injectable } from '@angular/core';
import { InConfiguration } from '../core/models/config.interface';

@Injectable({
  providedIn: 'root',
})
export class ConfigService {
  public configData: InConfiguration;

  constructor() {
    this.setConfigData();
  }

  setConfigData() {
    this.configData = {
      layout: {
        variant: 'light', // options:  light & dark
        theme_color: 'white', // options:  white, cyan, black, purple, orange, green, red
        sidebar: {
          collapsed: false, // options:  true & false
          backgroundColor: 'white', // options:  light & dark
        },
      },
    };
  }
}

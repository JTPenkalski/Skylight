import { ApplicationConfig, importProvidersFrom } from '@angular/core';
import { provideRouter, withComponentInputBinding } from '@angular/router';
import { NbEvaIconsModule } from '@nebular/eva-icons';
import { NbSidebarModule, NbThemeModule } from '@nebular/theme';

import { routes } from './app.routes';

export const appConfig: ApplicationConfig = {
  providers: [
    provideRouter(
      routes,
      withComponentInputBinding()
    ),
    importProvidersFrom(
      NbEvaIconsModule,
      NbThemeModule.forRoot({
        name: 'dark'
      }),
      NbSidebarModule.forRoot()
    )
  ]
};

import { ApplicationConfig, importProvidersFrom } from '@angular/core';
import { provideRouter } from '@angular/router';

import { routes } from './app.routes';
import { NbButtonModule, NbLayoutModule, NbSidebarModule, NbThemeModule } from '@nebular/theme';

export const appConfig: ApplicationConfig = {
  providers: [
    provideRouter(routes),
    importProvidersFrom(
      NbThemeModule.forRoot({
        name: 'dark'
      }),
      NbSidebarModule.forRoot()
    )
  ]
};

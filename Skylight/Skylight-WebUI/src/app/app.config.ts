import { ApplicationConfig, EnvironmentProviders, InjectionToken, importProvidersFrom, makeEnvironmentProviders } from '@angular/core';
import { provideHttpClient, withFetch, withInterceptors } from '@angular/common/http';
import { provideRouter, withComponentInputBinding } from '@angular/router';
import { NbEvaIconsModule } from '@nebular/eva-icons';
import { NbSidebarModule, NbThemeModule } from '@nebular/theme';

import { routes } from './app.routes';

import { environment } from 'environments/environment';

import { SKYLIGHT_BASE_API_URL } from 'web/clients';
import { credentialsInterceptor } from 'web/middleware';

export const appConfig: ApplicationConfig = {
  providers: [
    provideSkylightApiUrl(),
    provideHttpClient(
      withFetch(),
      withInterceptors([credentialsInterceptor])
    ),
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

function provideSkylightApiUrl(): EnvironmentProviders {
  return makeEnvironmentProviders([
    {
      provide: SKYLIGHT_BASE_API_URL,
      useValue: environment.skylightApiUrl
    }
  ]);
}

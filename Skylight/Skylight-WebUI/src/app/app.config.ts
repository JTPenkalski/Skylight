import { ApplicationConfig, EnvironmentProviders, importProvidersFrom, makeEnvironmentProviders } from '@angular/core';
import { provideHttpClient, withFetch, withInterceptors } from '@angular/common/http';
import { provideAnimations } from '@angular/platform-browser/animations';
import { provideRouter, withComponentInputBinding } from '@angular/router';
import { NbEvaIconsModule } from '@nebular/eva-icons';
import { NbMenuModule, NbSidebarModule, NbThemeModule, NbWindowModule } from '@nebular/theme';

import { routes } from './app.routes';

import { environment } from 'environments/environment';

import { SKYLIGHT_BASE_API_URL } from 'web/clients';
import { credentialsInterceptor } from 'web/middleware';

export const appConfig: ApplicationConfig = {
  providers: [
    provideSkylightApiUrl(),
    provideAnimations(),
    provideHttpClient(
      withFetch(),
      withInterceptors([credentialsInterceptor])
    ),
    provideNebular(),
    provideRouter(
      routes,
      withComponentInputBinding()
    ),
  ]
};

function provideNebular(): EnvironmentProviders {
  return importProvidersFrom(
    NbEvaIconsModule,
    NbMenuModule.forRoot(),
    NbThemeModule.forRoot({
      name: 'dark'
    }),
    NbSidebarModule.forRoot(),
    NbWindowModule.forRoot()
  );
}

function provideSkylightApiUrl(): EnvironmentProviders {
  return makeEnvironmentProviders([
    {
      provide: SKYLIGHT_BASE_API_URL,
      useValue: environment.skylightApiUrl
    }
  ]);
}

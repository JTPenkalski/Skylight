import { inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';
import { tap } from 'rxjs';
import { UserService } from 'shared/services';

export const authenticatedGuard: CanActivateFn = (route, state) => {
  const userService: UserService = inject(UserService);
  const router: Router = inject(Router);

  return userService.isSignedIn().pipe(
    tap((result) => {
      if (!result) {
        router.navigate(['/sign-in']);
      }
    }),
  );
};

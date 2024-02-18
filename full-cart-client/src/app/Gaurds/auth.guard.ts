import { inject } from '@angular/core';
import { CanActivateFn } from '@angular/router';
import { map } from 'rxjs';
import { AccountServiceService } from '../Services/account-service.service';

export const authGuard: CanActivateFn = (route, state) => {
  const accountService = inject(AccountServiceService);

  return accountService.currentUser$.pipe(
    (map(user => {
      if(user) {
        return true;
      } else {
        alert('Action Not Allowed !');
        return false;
      }
    }))
  )
};

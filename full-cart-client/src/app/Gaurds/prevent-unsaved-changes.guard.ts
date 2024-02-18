import { CanDeactivateFn } from '@angular/router';
import { MyProfileComponent } from '../Components/my-profile/my-profile.component';

export const preventUnsavedChangesGuard: CanDeactivateFn<MyProfileComponent> = (component) => {
  if(component.editForm?.dirty) {
    return confirm("Are you sure you want to continue ? Any unsaved changes will be lost")
  }
  return true;
};

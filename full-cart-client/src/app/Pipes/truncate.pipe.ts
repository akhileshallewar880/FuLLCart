import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'truncate'
})
export class TruncatePipe implements PipeTransform {
  transform(value: string): string {
    if (!value || value.length <= 30) {
      return value;
    } else {
      return value.substr(0, 30) + '...';
    }
  }
}

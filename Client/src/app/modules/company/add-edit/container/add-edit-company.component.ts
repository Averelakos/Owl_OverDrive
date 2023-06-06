import { Component } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { ResponsiveService, ResponsizeSize } from 'src/app/core/services/responsive.service';

@Component({
  selector: 'app-add-edit-company',
  templateUrl: './add-edit-company.component.html',
  styleUrls: ['./add-edit-company.component.scss']
})
export class AddEditCompanyComponent {
  imageSrc: string | ArrayBuffer | null;
  loading$ = new BehaviorSubject<boolean>(false)
  responsiveSizes = ResponsizeSize
  constructor(public responsiveService: ResponsiveService) {}

  readURL(event: any): void {
    if (event?.target.files && event.target.files[0]) {
        const file = event.target.files[0];

        const reader = new FileReader();
        reader.onload = e => this.imageSrc = reader.result;

        reader.readAsDataURL(file);
    }
  }
}

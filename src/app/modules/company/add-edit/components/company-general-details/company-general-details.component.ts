import { Component } from '@angular/core';
import { ResponsiveService, ResponsizeSize } from 'src/app/core/services/responsive.service';

@Component({
  selector: 'app-company-general-details',
  templateUrl: './company-general-details.component.html',
  styleUrls: ['./company-general-details.component.scss']
})
export class CompanyGeneralDetailsComponent {
  responsiveSizes = ResponsizeSize
  constructor(public responsiveService: ResponsiveService) {}
}

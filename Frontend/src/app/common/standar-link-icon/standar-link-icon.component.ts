import { Component, Input } from '@angular/core';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-standar-link-icon',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './standar-link-icon.component.html',
  styleUrls: ['./standar-link-icon.component.scss']
})
export class StandarLinkIconComponent {
  @Input() iconStyle:string = ''
  @Input() icon: string = ''
  @Input() linkName: string = ''
  @Input() link?: string | undefined

  clickToGoToLink(){
    window.open(this.link, "_blank");
  }
}

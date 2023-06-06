import { CommonModule } from '@angular/common';
import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-standar-loader',
  standalone: true,
  imports:[CommonModule],
  templateUrl: './standar-loader.component.html',
  styleUrls: ['./standar-loader.component.scss']
})
export class StandarLoaderComponent {
  @Input() loading!: boolean | null
}

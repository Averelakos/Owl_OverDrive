import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BannerResultActionService } from 'src/app/core/services/result-banner-action.service';
import { faL } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-result-banner',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './result-banner.component.html',
  styleUrls: ['./result-banner.component.scss']
})
export class ResultBannerComponent implements OnInit {
  bannerTimeout = 10000
  constructor(public resultBannerActionService: BannerResultActionService){}

  ngOnInit(): void {
    this.resultBannerActionService.displaySuccessBanner$.subscribe((s) => {
      setTimeout(() => {
        this.resultBannerActionService.clear()
      }, this.bannerTimeout)
    })

    this.resultBannerActionService.displayErrorBanner$.subscribe((s) => {
      setTimeout(() => {
        this.resultBannerActionService.clear()
      }, this.bannerTimeout)
    })

  }
}

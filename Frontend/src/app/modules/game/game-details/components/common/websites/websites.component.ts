import { Component, Input, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GameDetailsWebsiteDto } from 'src/app/data/types/game/game-details-dto';
import { EWebsites } from 'src/app/core/enums/enum-websites';

export interface WebsiteInfo{
  image: string
  url: string
  name: string
}

@Component({
  selector: 'app-websites',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './websites.component.html',
  styleUrls: ['./websites.component.scss']
})
export class WebsitesComponent implements OnInit {
  @Input() websites: Array<GameDetailsWebsiteDto> = []
  isthereStoreLinks: boolean = false
  isthereSocialLinks: boolean = false
  storeLinks: Array<WebsiteInfo> = []
  socialLinks: Array<WebsiteInfo> = []
  

  ngOnInit(): void {
    this.convertWebsites()
  }

  goToLink(url: string){
    window.open(url, "_blank");
  }

  convertWebsites(){
    if(this.websites.length > 0) {
      this.websites.forEach((site) => {
        switch (site.category){
          case EWebsites.android:
            this.isthereStoreLinks = true
            this.storeLinks.push( {
              image:'assets/icons/play-store.svg',
              url: site.url,
              name: 'Google play'
            } as WebsiteInfo)
            break
          case EWebsites.epicgames:
            this.isthereStoreLinks = true
            this.storeLinks.push( {
              image:'assets/icons/epic.svg',
              url: site.url,
              name: 'Epic'
            } as WebsiteInfo)
            break
          case EWebsites.iphone:
            this.isthereStoreLinks = true
            this.storeLinks.push( {
              image:'assets/icons/ios-iphone.svg',
              url: site.url,
              name: 'App Store (iPhone)'
            } as WebsiteInfo)
            break
          case EWebsites.itch:
            this.isthereStoreLinks = true
            this.storeLinks.push( {
              image:'assets/icons/itch.svg',
              url: site.url,
              name: 'Itch'
            } as WebsiteInfo)
            break
          case EWebsites.gog:
            this.isthereStoreLinks = true
            this.storeLinks.push( {
              image:'assets/icons/gog.svg',
              url: site.url,
              name: 'GOG'
            } as WebsiteInfo)
            break
          case EWebsites.steam:
            this.isthereStoreLinks = true
            this.storeLinks.push( {
              image:'assets/icons/steam.svg',
              url: site.url,
              name: 'Steam'
            } as WebsiteInfo)
            break
          case EWebsites.ipad:
            this.isthereStoreLinks = true
            this.storeLinks.push( {
              image:'assets/icons/ios-iphone.svg',
              url: site.url,
              name: 'App Store (iPad)'
            } as WebsiteInfo)
            break
          case EWebsites.official:
            this.isthereSocialLinks = true
            this.socialLinks.push( {
              image:'assets/icons/official-site.svg',
              url: site.url,
              name: 'Official Website'
            } as WebsiteInfo)
            break
          case EWebsites.twitch:
            this.isthereSocialLinks = true
            this.socialLinks.push( {
              image:'assets/icons/twitch.svg',
              url: site.url,
              name: 'Twitch'
            } as WebsiteInfo)
            break
          case EWebsites.youtube:
            this.isthereSocialLinks = true
            this.socialLinks.push( {
              image:'assets/icons/youtube.svg',
              url: site.url,
              name: 'YouTube'
            } as WebsiteInfo)
            break
          case EWebsites.facebook:
            this.isthereSocialLinks = true
            this.socialLinks.push( {
              image:'assets/icons/facebook.svg',
              url: site.url,
              name: 'Facebook'
            } as WebsiteInfo)
            break
          case EWebsites.twitter:
            this.isthereSocialLinks = true
            this.socialLinks.push( {
              image:'assets/icons/twitter.svg',
              url: site.url,
              name: 'Twitter'
            } as WebsiteInfo)
            break
          case EWebsites.instagram:
            this.isthereSocialLinks = true
            this.socialLinks.push( {
              image:'assets/icons/instagram.svg',
              url: site.url,
              name: 'Instagram'
            } as WebsiteInfo)
            break
          case EWebsites.discord:
            this.isthereSocialLinks = true
            this.socialLinks.push( {
              image:'assets/icons/discord.svg',
              url: site.url,
              name: 'Discord'
            } as WebsiteInfo)
            break
          case EWebsites.reddit:
            this.isthereSocialLinks = true
            this.socialLinks.push( {
              image:'assets/icons/reddit.svg',
              url: site.url,
              name: 'Subreddit'
            } as WebsiteInfo)
            break
          
        }
      })
    }
  }
}

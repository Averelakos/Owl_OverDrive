import { CommonModule } from "@angular/common"
import { Component, Input } from "@angular/core"
import { ResponsiveService, ResponsizeSize } from "src/app/core/services/responsive.service"

@Component({
    selector: 'spinner-loader',
    standalone: true,
    imports:[CommonModule],
    template: `
    <div class="spinner-container" [ngClass]="{'desktop':((this.responsiveService.responsiveSize | async) === responsiveSizes.Desktop)}" *ngIf="loading">
        <div class="loader-background">
            <div class="loader"></div>
            <div class="loader-image">
                <img  class="imageSize" [src]="imageSRC" alt="">
            </div>
        </div>
    </div>
    `,
    styles: [`
    .spinner-container{
        position: fixed;
        top:0;
        left: 0;
        right: 0;
        bottom:0;
        z-index:100;
        display: flex;
        align-items: center;
        justify-content: center;
    }

    /* .absolute{
        position: absolute;
        height:100%;
        width: 100%;
        background: red;

    } */

    .desktop{
        /* left: 270px; */
    }
    .loader-background {
        width:200px;
        padding: 5px;
        background-color: #222; 
        border-radius: 5px;
        position: relative;
        display: flex;
        align-items: center;
        justify-content: center;
    }
    .loader {
        width: 160px;
        aspect-ratio: 1;
        border-radius: 50%;
        border: 15px solid #c15375;
        animation:
        l20-1 0.8s infinite linear alternate,
        l20-2 1.6s infinite linear;
    
    }
    .loader-image{
        position: absolute;
        top: 55px;
        left: 65px;
    }

    .imageSize{
        width:65px;
        height:65px;
    }

    @keyframes l20-1{
        0%    {clip-path: polygon(50% 50%,0       0,  50%   0%,  50%    0%, 50%    0%, 50%    0%, 50%    0% )}
        12.5% {clip-path: polygon(50% 50%,0       0,  50%   0%,  100%   0%, 100%   0%, 100%   0%, 100%   0% )}
        25%   {clip-path: polygon(50% 50%,0       0,  50%   0%,  100%   0%, 100% 100%, 100% 100%, 100% 100% )}
        50%   {clip-path: polygon(50% 50%,0       0,  50%   0%,  100%   0%, 100% 100%, 50%  100%, 0%   100% )}
        62.5% {clip-path: polygon(50% 50%,100%    0, 100%   0%,  100%   0%, 100% 100%, 50%  100%, 0%   100% )}
        75%   {clip-path: polygon(50% 50%,100% 100%, 100% 100%,  100% 100%, 100% 100%, 50%  100%, 0%   100% )}
        100%  {clip-path: polygon(50% 50%,50%  100%,  50% 100%,   50% 100%,  50% 100%, 50%  100%, 0%   100% )}
    }
    @keyframes l20-2{ 
        0%    {transform:scaleY(1)  rotate(0deg)}
        49.99%{transform:scaleY(1)  rotate(135deg)}
        50%   {transform:scaleY(-1) rotate(0deg)}
        100%  {transform:scaleY(-1) rotate(-135deg)}
    }
    `]
  })
  export class SpinnerLoaderComponent {
    @Input() loading!: boolean | null
    @Input() inner: boolean = false
    @Input() imageSRC: string = ''
    responsiveSizes = ResponsizeSize
    constructor(public responsiveService: ResponsiveService){}
  }
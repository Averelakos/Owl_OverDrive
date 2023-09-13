import { CommonModule } from "@angular/common";
import { Component, Input } from "@angular/core";

@Component({
    selector: 'app-logo-loader',
    standalone: true,
    imports: [CommonModule],
    template: `
    <div class="logo-loader-container" [ngClass]="{'loading':isLoading}">
        <div class="ring">
            <img  class="imageSize" [src]="imageSRC" alt="">
        </div>
    </div>
    `,
    styles: [`
        :host {
            display: contents;
        }
        .logo-loader-container {
            width:100%;
            display: none;
            justify-content: center;
        }
        .loading {
            display: flex;
        }
        .ring{
            background: #222;
            width: 60px;
            height:60px;
            display: flex;
            justify-content: center;
            align-items: center;
            text-align: center;
            border-radius: 2rem;
        }
        .imageSize{
            width:40px;
            height:40px;
            animation: spin 2s infinite;
        }
        @keyframes spin {
            from {transform: rotate(0deg);}
            to {transform: rotate(360deg);}
        }
        
    `]
})
export class LogoLoader {
    @Input() imageSRC: string = ''
    @Input() isLoading: boolean | null = false
}
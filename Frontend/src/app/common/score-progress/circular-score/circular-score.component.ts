import { CommonModule } from "@angular/common";
import { AfterViewInit, Component, ElementRef, Input, OnInit, Renderer2, ViewChild } from "@angular/core";

@Component({
    selector: 'app-circular-score',
    standalone: true,
    imports: [CommonModule],
    template: `
    <div class="score">
        <a>
            <div [ngStyle]="{'background': setColorScore()}" class="circle">
                <span>{{score}}</span>
            </div>
        </a>
    </div>
    `,
    styles: [`
        :host {
            display: contents;
        }
        .score {
            width: 5%;
        }

        .circle {
            border-radius: 50%;
            border: 1px solid #000;
            height: 4rem;
            width: 4rem;
            font-size: 2.25rem;
            line-height: 2.5rem;
            /* background: #00ce7a; */
            display: flex;
            flex-direction: column;
            align-items: center;
            justify-content: center;
            font-weight: 700;
            color: #262626;
        }

        .circle span {
            font-size: 2.25rem;
            line-height: 2.5rem;
            font-weight: 700;
            color: #262626;
        }
        
    `]
})
export class CircularScoreComponent {
    @Input() score: number

    setColorScore(){
        switch(this.score){
            case 1:
                return 'red'
                break
            case 2:
                return 'red'
                break
            case 3:
            return 'red'
            break
            case 4:
                return 'orange'
                break
            case 5:
                return 'orange'
                break
            case 6:
            return 'orange'
            break
            case 7:
                return 'green'
                break
            case 8:
                return 'green'
                break
            case 9:
            return 'green'
            break
            case 10:
            return 'green'
            break
            default:
            return 'white'
        }
    }
}
import { CommonModule } from "@angular/common";
import { AfterViewInit, Component, ElementRef, Input, OnInit, Renderer2, ViewChild } from "@angular/core";

@Component({
    selector: 'app-circle-score-progress',
    standalone: true,
    imports: [CommonModule],
    template: `
    <div 
    #circleContainer 
    class="circle-score-progress-container"
    [style.width.px]="width"
    [style.height.px]="width"
    >
        <div class="precent">
            <svg>
                <circle cx="70" cy="70" [attr.r]="radius"></circle>
                <circle 
                #progressBar 
                cx="70" 
                cy="70" 
                [attr.r]="radius"
                [ngStyle]="{'stroke-dasharray':this.strokeDasharray, 'stroke-dashoffset': this.strokeDasharray}"
                ></circle>
            </svg>
            <div class="number">
                <h2>
                    {{precent}}
                    <span>
                        %
                    </span>
                </h2>
            </div>
        </div>
    </div>
    `,
    styles: [`
        :host {
            display: contents;
        }

        .circle-score-progress-container{
            position: relative;
            /* width: 136px;
            height: 136px; */
            display: flex;
            justify-content: center;
            align-items: center;
            flex-direction: column;
            background: #fff;
            box-shadow: 0 30px 60px rgba(0,0,0,.2);
            border-radius: 100%;

        }

        .circle-score-progress-container .precent{
            position: relative;
            width: 150px;
            height: 150px;
        }

        .circle-score-progress-container .precent svg{
            position: relative;
            width: 150px;
            height: 150px;
        }

        .circle-score-progress-container .precent svg circle{
            width: 150px;
            height: 150px;
            fill: none;
            stroke-width: 10;
            stroke: #000;
            transform: translate(5px, 5px);

            /* stroke-dasharray: 310; */
            /* stroke-dashoffset: 310; */
            stroke-linecap: round;
        }

        .circle-score-progress-container .precent svg circle:nth-child(1){
            stroke-dashoffset: 0;
            stroke: #f3f3f3;
            /* stroke: red; */
        }
        .circle-score-progress-container .precent svg circle:nth-child(2){
            /* stroke-dashoffset: calc(440 - (440 * 30) /100); */
            stroke: #03a9f4;
        }

        .circle-score-progress-container .precent  .number {
            position: absolute;
            top: 0;
            left: 0;
            width: 100%;
            height: 100%;
            display: flex;
            justify-content: center;
            align-items: center;
            color:#999;
        }
        .circle-score-progress-container .precent  .number h2 {
            /* font-size:48px; */
        }

        .circle-score-progress-container .precent  .number h2 span {
            /* font-size:24px; */
        }
    `]
})
export class CicleScoreProgressComponent implements AfterViewInit{
    @ViewChild('circleContainer', {static: false}) container : ElementRef
    @ViewChild('progressBar' , {static: false}) progressBar : ElementRef
    @Input() radius: number = 50;
    @Input() width: number = 136;
    @Input() strokeDasharray: number = 310
    @Input() precent:number = 10
    constructor(private renderer: Renderer2){
        
    }
    ngAfterViewInit(): void {
        this.renderer.setStyle(this.progressBar.nativeElement, 'stroke-dashoffset', `calc(${this.strokeDasharray} - (${this.strokeDasharray} *${this.precent} /100)`);
    }

}
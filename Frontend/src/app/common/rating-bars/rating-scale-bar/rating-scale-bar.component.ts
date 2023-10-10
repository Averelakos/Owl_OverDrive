import { CommonModule } from "@angular/common";
import { AfterViewInit, Component, ElementRef, EventEmitter, Input, OnInit, Output, Renderer2, ViewChild } from "@angular/core";

@Component({
    selector: 'app-rating-scale-bar',
    standalone: true,
    imports: [CommonModule],
    template: `
    <div class="rating-container" [ngStyle]="{'width': barWidth+'px'}">
        <div class="rating circular-right circular-left ">
            <input class="circular-right" type="radio" name="rating" id="rate10" (click)="clickRadio(10)">
            <label class="circular-right" for="rate10"></label>
            <input type="radio" name="rating" id="rate9" (click)="clickRadio(9)">
            <label for="rate9"></label>
            <input type="radio" name="rating" id="rate8" (click)="clickRadio(8)">
            <label for="rate8"></label>
            <input type="radio" name="rating" id="rate7" (click)="clickRadio(7)">
            <label for="rate7"></label>
            <input type="radio" name="rating" id="rate6" (click)="clickRadio(6)">
            <label for="rate6"></label>
            <input type="radio" name="rating" id="rate5" (click)="clickRadio(5)">
            <label for="rate5"></label>
            <input type="radio" name="rating" id="rate4" (click)="clickRadio(4)">
            <label for="rate4"></label>
            <input type="radio" name="rating" id="rate3" (click)="clickRadio(3)">
            <label for="rate3"></label>
            <input type="radio" name="rating" id="rate2" (click)="clickRadio(2)">
            <label for="rate2"></label>
            <input class="circular-left" type="radio" name="rating" id="rate1" (click)="clickRadio(1)">
            <label class="circular-left" for="rate1"></label>
        </div>
    </div>
    
    `,
    styles: [`
        :host {
            display: contents;
        }

        .rating-container {
            /* width:500px; */
            border-radius:20px
        }
        .rating{
            position: relative;
            display: flex;
            flex-direction: row-reverse;
            margin-top: 10px;
            border:1px solid #000;
            box-sizing: border-box;
            background: linear-gradient(to right, #f00, #ff0, #0f0)
        }

        .rating input{
            display: none;
        }

        .rating label {
            display: block;
            cursor: pointer;
            width: 50px;
            height: 10px;
            display: flex;
            align-items: center;
            justify-content: center;
            transition: 0.5s;
            background: #fff;
            color: #000;
            font-size: 20px;
            border-right: 1px solid #000;
        }

        .rating input[type='radio']:hover ~ label,
        .rating input[type='radio']:checked ~ label
        {
            background: transparent;
        }
      
        .circular-right {
            border-top-right-radius: 20px;
            border-bottom-right-radius: 20px;
        }
        .circular-left {
            border-top-left-radius: 20px;
            border-bottom-left-radius: 20px;
        }
    `]
})
export class RatingScaleBarComponent{
    @Input() barWidth: number = 500
    @Output() selectedScore = new EventEmitter<number>
    clickRadio(checked){
        this.selectedScore.emit(checked)
    }
}
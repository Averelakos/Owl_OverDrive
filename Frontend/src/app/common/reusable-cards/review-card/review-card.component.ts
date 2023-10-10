import { CommonModule } from "@angular/common";
import { Component,Input} from "@angular/core";
import { CircularScoreComponent } from "../../score-progress/circular-score/circular-score.component";

@Component({
    selector: 'app-review-card',
    standalone: true,
    imports: [CommonModule, CircularScoreComponent],
    template: `
     <div class="review-card">
                <div class="inner-card">
                    <div class="review-main">
                        <div class="review-main-header">
                            <app-circular-score [score]="model.score"></app-circular-score>
                            <a class="user-name">Iraklis</a>
                            <div class="post-date">{{model.postDate | date}}</div>
                        </div>
                        <div class="review-main-body">
                            <span>
                                {{model.review}}
                            </span>
                        </div>
                    </div>
                </div>
            </div>
    `,
    styles: [`
        :host {
            display: contents;
        }

        .inner-card{
    background-color: #f2f2f2;
    border-radius: 0.375rem;
    min-height: 300px;
    margin-bottom: 1.5rem;
}

.review-main{
    padding: 1rem;
}

.review-main-header {
    display: flex;
    flex-direction: row;
    gap: 0.5rem 1rem;
    align-items: center;
    text-align: center;
    margin-bottom: 1rem;
}

.user-name{
    display: flex;
    width: 75%;
    font-size: 1.5rem;
    line-height: 1.75rem;
    overflow: hidden;
    text-overflow: ellipsis;
    font-weight: 700;
    color: #262626;
    margin-left: 1rem;
}

.post-date{
    width: 20%;
    text-transform: uppercase;
    color: #404040;
}

.review-main-body{
    min-height: 4.5rem;
    font-size: 1rem;
    line-height: 1.5rem;
    overflow: hidden;
    text-overflow: ellipsis;
}

.review-main-body span {
    font-size: 1rem;
    line-height: 1.5rem;
}
    `]
})
export class ReviewCardComponent{
   
    @Input() model: any
}
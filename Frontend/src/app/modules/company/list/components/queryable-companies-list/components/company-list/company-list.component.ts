import { CommonModule } from "@angular/common";
import { Component, EventEmitter, Input, Output } from "@angular/core";
import { CompanySimpleDto } from "src/app/data/types/company/company-simple-dto";

@Component({
    selector: 'app-company-list',
    standalone: true,
    imports: [CommonModule],
    template: `
    <div class="company-list-container">
        <ul class="company-list-content">
            <li *ngFor="let company of companyList">
                <a (click)="selectCompany(company)">{{company.name}}</a>
            </li>
        </ul>
    </div>
    `,
    styles: [`
        :host {
            display: contents;
        }

        .company-list-container{
            width:100%;
            background: #c15375;
            border-radius: 3px;
        }

        .company-list-content{
            list-style: none;
            padding: 10px;
            box-sizing: border-box;
            // background:rgba(0,0,0,.1);
            background: #FAFAFA;
    box-shadow: 1px 1px 6px rgba(0, 0, 0, 0.2);
        }

        .company-list-content li {
            padding:10px 20px;
            line-height: 1.428571429;
            cursor: pointer;
            // background: rgba(255,255,255, 0.1);
            margin: 5px 0;
            transition:0.5s;
        }

        .company-list-content li a {
            display: flex;
            width: 100%;
        }

        .company-list-content li:nth-child(1) {
            background: rgba(255,255,255, 0.6);
        }

        .company-list-content li:nth-child(2) {
            background: rgba(255,255,255, 0.4);
        }

        .company-list-content li:nth-child(3) {
            background: rgba(255,255,255, 0.2);
        }
        .company-list-content li:hover{
            transform: scale(1.02);
            background: #c15375;
            color:#fff;
        }
        
        
    `]
})
export class CompanyListComponent {
    @Input() companyList: Array<CompanySimpleDto> = []
    @Output() clickEvent = new EventEmitter<CompanySimpleDto>

    selectCompany(company: CompanySimpleDto){
        console.log(company)
        this.clickEvent.emit(company)
    }
}
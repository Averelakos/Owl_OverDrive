import { CommonModule } from "@angular/common";
import { Component, EventEmitter, Input, Output } from "@angular/core";

@Component({
    selector: 'tabs',
    standalone: true,
    imports: [CommonModule],
    template: `
    <div class="tab-wrap">
        <ng-container *ngFor="let tab of tabs">
            <input  type="radio" class="tab" />
            <label  [ngClass]="{'checked-label': tab.active}" (click)="selectTab(tab)">{{tab.tabTitle}}</label>
        </ng-container>
        <section class="content checked">
            <ng-content #name></ng-content>
        </section>
    </div>

    `,
    styles: [`
        :host {
            display: contents;
        }

        .tab-wrap{
            transition: 0.3 box-shadow ease;
            /* border-radius: 6px; */
            max-width: 100%;
            display: flex;
            flex-wrap: wrap;
            position: relative;
            list-style: none;
            background-color: #fff;
            /* box-shadow: 0 1px 3px rgba(0, 0, 0, 0.12), 0 1px 2px rgba(0, 0, 0, 0.24); */
        }

        .tab{
            display: none;
        }

        label {
            box-shadow: 0 -1px 0 #eee inset;
            /* border-radius: 6px 6px 0 0; */
            cursor: pointer;
            display: block;
            text-decoration: none;
            color: #333;
            flex-grow: 3;
            text-align: center;
            background-color: #f2f2f2;
            user-select: none;
            text-align: center;
            transition: 0.3s background-color ease, 0.3s box-shadow ease;
            height: 50px;
            box-sizing: border-box;
            padding: 15px;
        }

        label:hover {
            background-color: #f9f9f9;
            box-shadow: 0 1px 0 #f4f4f4 inset;
        }

        .content {
            padding: 10px 25px;
            background-color: transparent;
            position: absolute;
            width: 100%;
            z-index: -1;
            opacity: 0;
            left: 0;
            transform: translateY(-3px);
            border-radius: 6px;
        }

        .checked{
            opacity:1;
            transition: 0,5s opacity ease in, 0.8s transform ease;
            position: relative;
            top: 0;
            z-index: 3;
            transform: translateY(0px);
            text-shadow: 0 0 0;
        }

        .checked-label {
            background-color: #fff;
            box-shadow: 0 -1px 0 #fff inset;
            cursor: default;
        }

        label:hover.checked-label {
            box-shadow: 0 -1px 0 #fff inset;
            background-color: #fff;
        }

        .checked-tab{
            opacity:1;
            transition: 0,5s opacity ease in, 0.8s transform ease;
            position: relative;
            top: 0;
            z-index: 3;
            transform: translateY(0px);
            text-shadow: 0 0 0;
        }


    `]
})
export class TabsComponent{
   
    tabs: TabComponent[] = [];

    addTab(tab: TabComponent) {
        if (this.tabs.length === 0) {
          tab.active = true;
        }
        this.tabs.push(tab);
    }

    selectTab(tab: TabComponent) {
        this.tabs.forEach((tab) => {
          tab.active = false;
        });
        tab.active = true;
    }
}

@Component({
    selector: 'tab',
    standalone: true,
    imports: [CommonModule],
    template: `
    <div [hidden]="!active">
        <h3 >{{tabTitle}}</h3>
        <ng-content #name></ng-content>
    </div>
    `,
    styles: [`
        :host {
            display: contents;
        }

        h3 {
           font-weight: 400;
        }

    `]
})
export class TabComponent {
    @Input() tabTitle: string
    active: boolean
    constructor(tabs: TabsComponent){
        tabs.addTab(this)
    }
}
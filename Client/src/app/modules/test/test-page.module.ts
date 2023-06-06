import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { TestingAreaComponent } from './testing-area/testing-area.component';
import { PlaygroundComponent } from './playground/playground.component';

const routes: Routes = [
    {path:'testarea', component:TestingAreaComponent},
    {path:'playground', component:PlaygroundComponent}
]

@NgModule({
    imports:[
        RouterModule.forChild(routes)
        // BrowserModule,
    ],
    providers:[],
    declarations:[
    TestingAreaComponent,
    PlaygroundComponent
  ],
    exports:[
        TestingAreaComponent,
        PlaygroundComponent,
        RouterModule
    ]
})
export class TestPageModule{}
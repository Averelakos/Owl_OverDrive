import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'src/app/lib/toastr/toastr.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  constructor(private toastr: ToastrService) { }

  ngOnInit(): void {
  }

  show(){
    this.toastr.success('Hello world!', 'Toastr fun!');
  }

}

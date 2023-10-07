import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MatDatetimePickerComponent } from './mat-datetime-picker.component';

describe('MatDatetimePickerComponent', () => {
  let component: MatDatetimePickerComponent;
  let fixture: ComponentFixture<MatDatetimePickerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MatDatetimePickerComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(MatDatetimePickerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

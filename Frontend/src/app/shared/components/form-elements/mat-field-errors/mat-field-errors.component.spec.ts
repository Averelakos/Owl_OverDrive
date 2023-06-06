import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MatFieldErrorsComponent } from './mat-field-errors.component';

describe('MatFieldErrorsComponent', () => {
  let component: MatFieldErrorsComponent;
  let fixture: ComponentFixture<MatFieldErrorsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MatFieldErrorsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(MatFieldErrorsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BirthdateSelectorsComponent } from './birthdate-selectors.component';

describe('BirthdateSelectorsComponent', () => {
  let component: BirthdateSelectorsComponent;
  let fixture: ComponentFixture<BirthdateSelectorsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BirthdateSelectorsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(BirthdateSelectorsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

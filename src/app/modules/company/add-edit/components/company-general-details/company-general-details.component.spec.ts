import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CompanyGeneralDetailsComponent } from './company-general-details.component';

describe('CompanyGeneralDetailsComponent', () => {
  let component: CompanyGeneralDetailsComponent;
  let fixture: ComponentFixture<CompanyGeneralDetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CompanyGeneralDetailsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CompanyGeneralDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

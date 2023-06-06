import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminSidebarMobileComponent } from './admin-sidebar-mobile.component';

describe('AdminSidebarMobileComponent', () => {
  let component: AdminSidebarMobileComponent;
  let fixture: ComponentFixture<AdminSidebarMobileComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AdminSidebarMobileComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AdminSidebarMobileComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

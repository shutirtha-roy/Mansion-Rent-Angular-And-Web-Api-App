import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MansionNumberListComponent } from './mansion-number-list.component';

describe('MansionNumberListComponent', () => {
  let component: MansionNumberListComponent;
  let fixture: ComponentFixture<MansionNumberListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MansionNumberListComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(MansionNumberListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

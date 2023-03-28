import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MansionNumberComponent } from './mansion-number.component';

describe('MansionNumberComponent', () => {
  let component: MansionNumberComponent;
  let fixture: ComponentFixture<MansionNumberComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MansionNumberComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(MansionNumberComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

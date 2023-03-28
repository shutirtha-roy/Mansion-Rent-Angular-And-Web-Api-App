import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MansionComponent } from './mansion.component';

describe('MansionComponent', () => {
  let component: MansionComponent;
  let fixture: ComponentFixture<MansionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MansionComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(MansionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddMansionComponent } from './add-mansion.component';

describe('AddMansionComponent', () => {
  let component: AddMansionComponent;
  let fixture: ComponentFixture<AddMansionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddMansionComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AddMansionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

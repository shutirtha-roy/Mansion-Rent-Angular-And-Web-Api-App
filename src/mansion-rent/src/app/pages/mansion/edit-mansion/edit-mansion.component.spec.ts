import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditMansionComponent } from './edit-mansion.component';

describe('EditMansionComponent', () => {
  let component: EditMansionComponent;
  let fixture: ComponentFixture<EditMansionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EditMansionComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EditMansionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

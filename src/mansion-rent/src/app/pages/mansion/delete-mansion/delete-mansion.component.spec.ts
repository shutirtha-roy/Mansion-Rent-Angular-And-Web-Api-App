import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DeleteMansionComponent } from './delete-mansion.component';

describe('DeleteMansionComponent', () => {
  let component: DeleteMansionComponent;
  let fixture: ComponentFixture<DeleteMansionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DeleteMansionComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DeleteMansionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

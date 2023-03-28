import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MansionListComponent } from './mansion-list.component';

describe('MansionListComponent', () => {
  let component: MansionListComponent;
  let fixture: ComponentFixture<MansionListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MansionListComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(MansionListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

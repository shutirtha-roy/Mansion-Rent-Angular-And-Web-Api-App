import { TestBed } from '@angular/core/testing';

import { MansionServiceService } from './mansion-service.service';

describe('MansionServiceService', () => {
  let service: MansionServiceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(MansionServiceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});

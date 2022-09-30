import { TestBed } from '@angular/core/testing';

import { ZzggService } from './zzgg.service';

describe('ZzggServiceService', () => {
  let service: ZzggService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ZzggService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});

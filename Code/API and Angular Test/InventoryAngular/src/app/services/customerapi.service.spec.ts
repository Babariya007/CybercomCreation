import { TestBed } from '@angular/core/testing';

import { CustomerapiService } from './customerapi.service';

describe('CustomerapiService', () => {
  let service: CustomerapiService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CustomerapiService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});

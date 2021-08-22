import { TestBed } from '@angular/core/testing';

import { ClassNameService } from './classname.service';

describe('ClassNameService', () => {
    let service: ClassNameService;

    beforeEach(() => {
        TestBed.configureTestingModule({});
        service = TestBed.inject(ClassNameService);
      });

      it('should be created', () => {
        expect(service).toBeTruthy();
      });
});
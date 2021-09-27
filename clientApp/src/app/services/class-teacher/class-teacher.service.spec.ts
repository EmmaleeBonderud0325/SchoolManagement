import { TestBed } from '@angular/core/testing';

import { ClassTeacherService } from './class-teacher.service';

describe('ClassTeacherService', () => {
    let service: ClassTeacherService;

    beforeEach(() => {
        TestBed.configureTestingModule({});
        service = TestBed.inject(ClassTeacherService);
      });

      it('should be created', () => {
        expect(service).toBeTruthy();
      });
});
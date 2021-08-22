
import {​​​​​​​​ TestBed }​​​​​​​​ from'@angular/core/testing';
 
import {​​​​​​​​ EssayQuestionAnswerService }​​​​​​​​ from'./essay-answer.service';
 
describe('EssayQuestionAnswer', () => {​​​​​​​​
let service: EssayQuestionAnswerService;
 
beforeEach(() => {​​​​​​​​
TestBed.configureTestingModule({​​​​​​​​}​​​​​​​​);
service = TestBed.inject(EssayQuestionAnswerService);
      }​​​​​​​​);
 
it('should be created', () => {​​​​​​​​
expect(service).toBeTruthy();
      }​​​​​​​​);
}​​​​​​​​);


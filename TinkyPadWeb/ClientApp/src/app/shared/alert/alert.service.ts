import { Injectable } from "@angular/core";
import { Subject } from "rxjs";

@Injectable()
export class AlertService {
  newAlert: Subject<{message: string, isQuestion: boolean}> = new Subject();
  private okAnswerCallback: () => void;
  
  showAlert(alertMessage: string) {
    this.newAlert.next({message: alertMessage, isQuestion: false});
  }

  showQuestion(question: string, okCallback: () => void) {
    this.okAnswerCallback = okCallback;
    this.newAlert.next({message: question, isQuestion: true});
  }

  onOkAnswer() {
    this.okAnswerCallback();
  }
}

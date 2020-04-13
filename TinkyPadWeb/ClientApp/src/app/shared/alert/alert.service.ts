import { Injectable } from "@angular/core";
import { Subject } from "rxjs";

@Injectable()
export class AlertService {
  newAlert: Subject<string> = new Subject();
  
  showAlert(alertMessage: string) {
    this.newAlert.next(alertMessage);
  }
}

import {
  Component,
  EventEmitter,
  Output, 
  Input} from '@angular/core';

@Component({
  selector: 'app-alert',
  templateUrl: './alert.component.html',
  styleUrls: ['alert.component.css']
})
export class AlertComponent {
  @Output() close = new EventEmitter<void>();
  @Output() okAnswer = new EventEmitter<void>();
  @Input() message: string = null;
  @Input() isOkCancelQuestion = false;

  onClose() {
    this.close.emit();
  }

  onOkAnswer() {
    this.okAnswer.emit();
  }

}

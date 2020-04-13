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
  @Input() message: string = null;

  onClose() {
    this.close.emit();
  }

}

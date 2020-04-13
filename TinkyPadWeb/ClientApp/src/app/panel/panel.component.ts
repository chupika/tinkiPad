import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { PanelService } from './panel.service';
import { AlertService } from '../shared/alert/alert.service';

@Component({
  selector: 'app-panel',
  templateUrl: './panel.component.html',
  styleUrls: ['./panel.component.css']
})
export class PanelComponent {

  constructor(
    private panelService: PanelService,
    private alertService: AlertService,
    private router: Router) {}

  onNewTask() {
    this.router.navigate(['new']);
  }

  onChoose() {
    const restriction = this.panelService.checkRestrictionToChoose();
    if (restriction) {
      this.alertService.showAlert(restriction);
      return;
    }
  }

  onComplete() {

  }

  onInterrupt() {

  }

  onTurnThePage() {

  }

  chooseTaskAvailable() {
    return this.panelService.isChooseAvailable();
  }
}

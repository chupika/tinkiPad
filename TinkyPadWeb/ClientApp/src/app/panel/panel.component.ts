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
    if (!this.chooseTaskAvailable()) {
      return;
    }
    
    const restriction = this.panelService.checkRestrictionToChoose();
    if (restriction) {
      this.alertService.showAlert(restriction);
      return;
    }

    this.panelService.chooseSelectedTask();
  }

  onComplete() {
    this.panelService.completeTask();
  }

  onInterrupt() {
    this.panelService.interruptTask();
  }

  onTurnThePage() {
    if (!this.panelService.anyTaskChosenOnThisTurn()) {
      this.showKillPageDialog();
      return;
    }

    this.activateNextPage();
  }

  chooseTaskAvailable() {
    return this.panelService.isChooseAvailable();
  }

  completeTaskAvailable() {
    return this.panelService.isCompleteTaskAvailable();
  }

  showKillPageDialog() {
    const killPageQuestion = 'You cannont turn this page because you have not chosen any task to do on this turn. '
      + 'But if you want turn this page anyway you have to complete all tasks on the current active page. '
      + 'Complete all tasks on current active page?';

    this.alertService.showQuestion(killPageQuestion, this.killPage.bind(this));
  }

  killPage() {
    this.panelService.killPage();
    this.activateNextPage();    
  }

  private activateNextPage() {
    this.panelService.turnThePage();
    const nextActivePageIndex = this.panelService.getActivePageIndex();
    this.router.navigate([nextActivePageIndex]);
  }
}

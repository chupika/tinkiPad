import { Injectable } from '@angular/core';

import { PageService } from '../shared/page.service';
import { PadService } from '../shared/pad.service';

@Injectable()
export class PanelService {
  constructor(private pageService: PageService, private padService: PadService) {}

  isChooseAvailable() {
    return this.pageService.selectedTaskIndexOnPage != null;
  }

  isCompleteTaskAvailable() {
    return this.padService.isActiveTaskChosen();
  }

  checkRestrictionToChoose() {
    if (this.padService.isActiveTaskChosen()) {
      return 'Active task is alread chosen. Complete it or interrupt, if you want to start another one.';
    }

    if (this.pageService.openedPageIndex != this.padService.getActivePageIndex()) {
      return 'You cannot choose task from not active page.'
    }

    if (this.padService.getTaskFromActivePage(this.pageService.selectedTaskIndexOnPage).isCompleted) {
      return 'You cannot choose completed or interrupted task.'
    }

    return null;
  }

  chooseSelectedTask() {
    const selectedTaskIndexOnPage = this.pageService.selectedTaskIndexOnPage;
    this.padService.setActiveTask(selectedTaskIndexOnPage);
  }

  completeTask() {
    this.padService.completeTask();
  }

  interruptTask() {
    this.padService.interruptTask();
  }

  turnThePage() {
    this.pageService.setNextActivePage();
  }

  getActivePageIndex() {
    return this.padService.getActivePageIndex();
  }

  anyTaskChosenOnThisTurn() {
    return this.padService.anyTasksChosenOnThisTurn();
  }
}

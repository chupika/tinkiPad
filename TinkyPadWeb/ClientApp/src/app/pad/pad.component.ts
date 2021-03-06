import { Component, OnInit, OnDestroy } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { Subscription } from 'rxjs';

import { PadService } from 'src/app/shared/pad.service';
import { Task } from 'src/app/shared/task.model';
import { TaskStatus } from '../shared/task-status';
import { PageService } from '../shared/page.service';
import { AlertService } from '../shared/alert/alert.service';

@Component({
  selector: 'app-pad',
  templateUrl: './pad.component.html',
  styleUrls: ['./pad.component.css']
})
export class PadComponent implements OnInit, OnDestroy {
  tasks: Task[];
  activeTaskIndexOnPage: number;
  paramsSubscription: Subscription;
  taskChangedSubscription: Subscription;
  alertSubscription: Subscription;
  pageIndex: number;
  alertMessage: string;
  isOkCancelQuestion: boolean;

  constructor(private padService: PadService,
              private pageService: PageService,
              private route: ActivatedRoute,
              private router: Router,
              private alertService: AlertService) { }

  ngOnInit(): void {
    this.paramsSubscription = this.route.params
      .subscribe(
        (params: Params) => {
          const idPage = +params['idpage'];
          const pageCount = this.pageService.pageCount();
          if (!isNaN(idPage) && idPage >= 0 && idPage < pageCount) {
            this.initializePage(idPage);
          } else {
            this.router.navigate(['page-not-found']);
          }
        }
      );

    this.taskChangedSubscription = this.padService.tasksChanged
      .subscribe(() => {
        this.initializePage(this.pageIndex);
      });

    this.alertSubscription = this.alertService.newAlert
      .subscribe((alertInfo) => {
        this.alertMessage = alertInfo.message;
        this.isOkCancelQuestion = alertInfo.isQuestion;
      });
  }

  getStatusClasses(task: Task, index: number) {
    const taskStatus = this.getTaskStatus(task, index);
    
    return {
      'list-group-item-secondary': taskStatus === TaskStatus.General,
      'list-group-item-completed': taskStatus === TaskStatus.Completed,
      'list-group-item-primary': taskStatus === TaskStatus.Active
    };
  }

  ngOnDestroy(): void {
    this.paramsSubscription.unsubscribe();
    this.taskChangedSubscription.unsubscribe();
    this.alertSubscription.unsubscribe();
    this.pageService.clearOpenedPage();
    this.pageService.clearSelectedTask();
  }

  onAlertClose() {
    this.alertMessage = null;
  }

  onOkAnswer() {
    this.alertMessage = null;
    this.alertService.onOkAnswer();
  }

  private initializePage(pageIndex: number) {
    this.pageIndex = pageIndex;
    this.pageService.openedPageIndex = this.pageIndex;
    this.tasks = this.padService.getTasksFromPage(this.pageIndex);
    this.activeTaskIndexOnPage = this.padService.getActiveTaskIndexOnPage();
  }

  private getTaskStatus(task: Task, index: number): TaskStatus {
    if (this.activeTaskIndexOnPage === index
        && this.pageIndex === this.padService.getActivePageIndex()) {
      return TaskStatus.Active;
    }

    if (task.isCompleted) {
      return TaskStatus.Completed;
    }

    return TaskStatus.General;
  }

  onPreviousPage() {
    this.router.navigate([this.pageIndex - 1]);
  }

  onActivePage() {
    const activePageIndex = this.padService.getActivePageIndex();
    this.router.navigate([activePageIndex]);
  }

  onNextPage() {
    this.router.navigate([this.pageIndex + 1]);
  }

  previousPageAvailable() {
    return this.pageIndex > 0; 
  }

  nextPageAvailable() {
    return this.pageIndex < this.pageService.pageCount() - 1;
  }
}

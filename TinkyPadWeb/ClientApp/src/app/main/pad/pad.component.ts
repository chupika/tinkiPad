import { Component, OnInit, OnDestroy } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { Subscription } from 'rxjs';

import { PadService } from 'src/app/shared/pad.service';
import { Task } from 'src/app/shared/task.model';
import { TaskStatus } from '../../shared/task-status';
import { PageService } from '../../shared/page.service';

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
  pageIndex: number;

  constructor(private padService: PadService,
              private pageService: PageService,
              private route: ActivatedRoute,
              private router: Router) { }

  ngOnInit(): void {
    this.paramsSubscription = this.route.params
      .subscribe(
        (params: Params) => {
          const idPage = +params['idpage'];
          const pageCount = this.pageService.pageCount();
          if (!isNaN(idPage) && idPage >= 0 && idPage < pageCount - 1) {
            this.initializePage(+params['idpage']);
          } else {
            this.router.navigate(['page-not-found']);
          }
        }
      );

    this.taskChangedSubscription = this.padService.tasksChanged
      .subscribe(() => {
      this.initializePage(this.pageIndex);
    });
  }

  getStatusClasses(task: Task, index: number) {
    const taskStatus = this.getTaskStatus(task, index);
    
    return {
      'list-group-item-secondary': taskStatus === TaskStatus.General || taskStatus === TaskStatus.Empty,
      'list-group-item-completed': taskStatus === TaskStatus.Completed,
      'list-group-item-primary': taskStatus === TaskStatus.Active
    };
  }

  getTasksFromPageWithAppendix(pageIndex: number) {
    let originalTasks = this.padService.getTasksFromPage(pageIndex);

    if (this.padService.isPageFilled(pageIndex)) {
      return originalTasks;
    }

    const appendixEmptyTasks: Task[] = [];
    const emptyTasksCount =  this.padService.getPageCapacity() - originalTasks.length;

    for (let i = 0; i < emptyTasksCount; i++) {
      let emptyTask = new Task();
      appendixEmptyTasks.push(emptyTask);
    }

    originalTasks.push(...appendixEmptyTasks);

    return this.padService.getTasksFromActivePage();   
  }

  ngOnDestroy(): void {
    this.paramsSubscription.unsubscribe();
    this.taskChangedSubscription.unsubscribe();
  }

  private initializePage(pageIndex: number) {
    this.pageIndex = pageIndex;
    this.pageService.setPage(this.pageIndex);
    this.tasks = this.getTasksFromPageWithAppendix(this.pageIndex);
    this.activeTaskIndexOnPage = this.padService.getActiveTaskIndexOnPage();
  }

  private getTaskStatus(task: Task, index: number): TaskStatus {
    if (task.name === '') {
      return TaskStatus.Empty;
    }

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
}

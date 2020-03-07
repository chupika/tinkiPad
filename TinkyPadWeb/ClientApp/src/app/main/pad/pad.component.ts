import { Component, OnInit, OnDestroy } from '@angular/core';
import { ActivatedRoute, Params } from '@angular/router';
import { Subscription } from 'rxjs';

import { PadService } from 'src/app/shared/pad.service';
import { Task } from 'src/app/shared/task.model';
import { TaskStatus } from '../../shared/task-status';

@Component({
  selector: 'app-pad',
  templateUrl: './pad.component.html',
  styleUrls: ['./pad.component.css']
})
export class PadComponent implements OnInit, OnDestroy {
  tasks: Task[];
  activeTaskIndexOnPage: number;
  paramsSubscription: Subscription;
  pageIndex: number;

  constructor(private padService: PadService, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.paramsSubscription = this.route.params
      .subscribe(
        (params: Params) => {
          const pageIndex = +params['idpage'];
          this.tasks = this.getTaskFromPage(pageIndex);
          this.activeTaskIndexOnPage = this.padService.getActiveTaskIndexOnPage();
        }
      );
  }

  getStatusClasses(task: Task, index: number) {
    const taskStatus = this.getTaskStatus(task, index);
    
    return {
      'list-group-item-secondary': taskStatus === TaskStatus.General || taskStatus === TaskStatus.Empty,
      'list-group-item-light': taskStatus === TaskStatus.Done,
      'list-group-item-primary': taskStatus === TaskStatus.Active
    };
  }

  getTaskFromPage(pageIndex: number) {
    let originalTasks = this.padService.getTasksFromActivePage();

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

  private getTaskStatus(task: Task, index: number): TaskStatus {
    if (task.name === '') {
      return TaskStatus.Empty;
    }

    if (this.activeTaskIndexOnPage === index) {
      return TaskStatus.Active;
    }

    if (task.isDone) {
      return TaskStatus.Done;
    }

    return TaskStatus.General;
  }

  ngOnDestroy(): void {
    this.paramsSubscription.unsubscribe();
  }
}

import { Injectable } from '@angular/core';

import { PadProviderService } from './pad-provider.service';
import { Pad } from './pad.model';
import { Task } from './task.model';
import { Subject } from 'rxjs';

@Injectable()
export class PadService {
  private pad: Pad;
  tasksChanged = new Subject();  

  constructor(private tasksProviderService: PadProviderService) {
    this.pad = this.tasksProviderService.getPad();
  }

  setActiveTask(taskIndexOnPage: number) {
    this.pad.setActiveTaskByIndexOnPage(taskIndexOnPage);
    this.notifyTasksChanged();
  }

  getActiveTask(): Task {
    return this.pad.getActiveTask();
  }

  getActivePageIndex(): number {
    return this.pad.getActivePageIndex();
  }

  getTasksFromActivePage(): Task[] {
    return this.pad.getTasksFromActivePage();
  }

  getTaskFromActivePage(taskIndexOnPage: number): Task {
    return this.pad.getTasksFromActivePage()[taskIndexOnPage];
  }

  getTasksFromPage(pageIndex: number): Task[] {
    return this.pad.getTasksFromPage(pageIndex);
  }

  isActiveTaskChosen(): boolean {
    return this.pad.getActiveTaskIndex() !== -1;
  }

  getActiveTaskIndexOnPage(): number {
    const activeTaskGlobalIndex = this.pad.getActiveTaskIndex();

    if (activeTaskGlobalIndex === -1) {
      return activeTaskGlobalIndex;
    }

    return activeTaskGlobalIndex - this.pad.getActivePageIndex() * this.pad.tasksOnPage;
  }

  isPageFilled(pageIndex: number) {
    const lastTaskIndexOnPage = (pageIndex + 1) * this.pad.tasksOnPage - 1;
    const lastTaskIndex = this.pad.tasks.length - 1;
    return lastTaskIndexOnPage <= lastTaskIndex;
  }

  getPageCapacity() {
    return this.pad.tasksOnPage;
  }
  
  getTaskFromPage(pageIndex: number, taskIndexOnPage: number) {
    const taskFromPage = this.pad.getTasksFromPage(pageIndex);
    return taskFromPage[taskIndexOnPage];
  }

  updateTask(pageIndex: number, taskIndexOnPage: number, task: Task) {
    const globalIndex = pageIndex * this.pad.tasksOnPage + taskIndexOnPage;
    this.pad.tasks[globalIndex] = task;
    this.notifyTasksChanged();
  }

  addTask(task: Task) {
    this.pad.pushTask(task);
    this.notifyTasksChanged();
  }

  getPageCount() {
    const pageCount = Math.floor(this.pad.tasks.length / this.pad.tasksOnPage) + 1;
    return pageCount;
  }

  completeTask() {
    this.pad.getActiveTask().isCompleted = true;
    this.pad.setActiveTaskIndex(-1);
    this.notifyTasksChanged();
  }

  interruptTask() {
    const activeTask = this.pad.getActiveTask();
    const clonedTask = activeTask.cloneTask();
    activeTask.isCompleted = true;
    this.pad.setActiveTaskIndex(-1);
    this.pad.pushTask(clonedTask);
    this.notifyTasksChanged();
  }

  setActivePage(pageIndex: number) {
    this.pad.setActivePageIndex(pageIndex);
  }

  private notifyTasksChanged() {
    this.tasksChanged.next();
  }
}

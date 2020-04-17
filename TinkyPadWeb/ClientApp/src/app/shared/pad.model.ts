import { Task } from './task.model';

export class Pad {
  tasks: Task[] = [];
  tasksOnPage = 20;
  
  private activeTaskIndex = -1;
  private activePageIndex = 0;
  private _anyTaskChosenOnThisTurn = false;

  constructor() { }

  pushTask(task: Task) {
    this.tasks.push(task);
  }

  getTasks() {
    return this.tasks.slice();
  }

  getActiveTask(): Task {
    if (this.activeTaskIndex === -1) {
      return null;
    }

    return this.tasks[this.activeTaskIndex];
  }

  setActiveTaskIndex(index: number): void {
    if (index >= this.tasks.length) {
      throw new Error('Index exceeds quantity');
    }

    if (index != -1 && this.tasks[index].isCompleted) {
      throw new Error('Task with such index is done');
    }

    this.activeTaskIndex = index;
    this._anyTaskChosenOnThisTurn = true;

    if (index != -1) {
      this.activePageIndex = Math.floor(index / this.tasksOnPage);
    }
  }

  setActiveTaskByIndexOnPage(taskIndexOnPage: number) {
    const globalTaskIndex = this.tasksOnPage * this.getActivePageIndex() + taskIndexOnPage;
    this.setActiveTaskIndex(globalTaskIndex);
  }

  getActivePageIndex(): number {
    return this.activePageIndex;
  }

  getActiveTaskIndex() {
    return this.activeTaskIndex;
  }

  getTasksFromActivePage() {
    return this.getTasksFromPage(this.activePageIndex);
  }

  getTasksFromPage(pageIndex: number) {
    const taskIndexStart = pageIndex * this.tasksOnPage;
    return this.tasks.slice(taskIndexStart, taskIndexStart + this.tasksOnPage);
  }

  setActivePageIndex(pageIndex: number) {
    if (this.activePageIndex == pageIndex) {
      return;
    }

    const pageCount = Math.floor(this.tasks.length / this.tasksOnPage) + 1;
    if (pageIndex < pageCount) {
      this.activePageIndex = pageIndex;
      this._anyTaskChosenOnThisTurn = false;
    }
  }

  get anyTaskChosenOnThisTurn() {
    return this._anyTaskChosenOnThisTurn;
  }
}

import { Task } from './task.model';

export class Pad {
  tasks: Task[] = [];
  tasksOnPage = 20;
  
  private activeTaskIndex = -1;
  private activePageIndex = 0;

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

    let task = this.tasks[index];
    if (task.isCompleted) {
      throw new Error('Task with such index is done');
    }

    this.activeTaskIndex = index;
    this.activePageIndex = Math.floor(index / this.tasksOnPage);
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
}
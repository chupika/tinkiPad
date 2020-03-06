import { Task } from './task.model';

export class Pad {
  tasks: Task[] = [];
  activeTaskIndex = -1;
  tasksOnPage = 20;

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
}
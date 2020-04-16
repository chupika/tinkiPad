export class Task {
  name: string;
  description: string;
  isCompleted = false;

  constructor(name: string = '', description: string = '') {
    this.name = name;
    this.description = description;
  }

  cloneTask() {
    return new Task(this.name, this.description);
  }
}
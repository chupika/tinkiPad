import { Pad } from "./pad.model";
import { Task } from "./task.model";

export class PadProviderServiceMock {
  
  getPad(): Pad {
    const tasksCount = 45;
    const doneTasksIndexes = [2, 3, 4, 10, 21, 22];
    const activeTaskIndex = 25;

    const pad = new Pad();
    
    for (let i = 0; i < tasksCount; i++) {
      const taskName = 'task name ' + i;
      const taskDescription = 'task description ' + i;
      const task = new Task(taskName, taskDescription);
        
      task.isCompleted = doneTasksIndexes.includes(i);

      pad.pushTask(task);
    }

    //pad.setActiveTaskIndex(activeTaskIndex);

    return pad;
  }
}

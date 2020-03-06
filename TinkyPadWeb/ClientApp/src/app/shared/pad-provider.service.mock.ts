import { Injectable } from "@angular/core";

import { Pad } from "./pad.model";
import { Task } from "./task.model";
import { PadProviderInterface } from './pad-provider.interface';

export class PadProviderServiceMock implements PadProviderInterface {
  
  getPad(): Pad {
    const tasksCount = 45;
    const doneTasksIndexes = [2, 3, 4, 10, 21, 22];
    const activeTaskIndex = 25;

    const pad = new Pad();
    
    for (let i = 0; i < tasksCount; i++) {
      const taskName = 'task name ' + i;
      const taskDescription = 'task description ' + i;
      const task = new Task(taskName, taskDescription);
        
      task.isDone = doneTasksIndexes.includes(i);

      pad.pushTask(task);
    }

    pad.activeTaskIndex = activeTaskIndex;

    return pad;
  }
}

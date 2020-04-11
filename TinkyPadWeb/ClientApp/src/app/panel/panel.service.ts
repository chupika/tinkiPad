import { PadService } from '../shared/pad.service';
import { Task } from '../shared/task.model';
import { Injectable } from '@angular/core';

@Injectable()
export class PanelService {
  constructor(private padService: PadService) {}

  addTask(task: Task) {
    this.padService.addTask(task);
  }
}

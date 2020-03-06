import { Injectable } from '@angular/core';

import { PadProviderService } from './pad-provider.service';
import { Pad } from './pad.model';
import { Task } from './task.model';

@Injectable()
export class PadService {
  private pad: Pad;

  constructor(private tasksProviderService: PadProviderService) {
    this.pad = this.tasksProviderService.getPad();
  }

  getActiveTask(): Task {
    return this.pad.getActiveTask();
  }
}
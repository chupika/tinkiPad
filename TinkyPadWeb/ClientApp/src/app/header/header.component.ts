import { Component, OnInit } from '@angular/core';
import { PadService } from 'src/app/shared/pad.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {
  activeTaskName = '';

  constructor(private padService: PadService) { }

  ngOnInit(): void {
    if (this.padService.isActiveTaskChosen()) {
      this.activeTaskName = this.padService.getActiveTask().name;
    }

    this.padService.tasksChanged.subscribe(() => {
      const newActiveTask = this.padService.getActiveTask();
      const newActiveTaskName = newActiveTask ? newActiveTask.name : '';
      if (this.activeTaskName !== newActiveTaskName) {
        this.activeTaskName = newActiveTaskName;
      }
    })
  }
}

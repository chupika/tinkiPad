import { Component, OnInit } from '@angular/core';
import { PadService } from '../shared/pad.service';
import { Task } from '../shared/task.model';
import { Router } from '@angular/router';

@Component({
  selector: 'app-active-task',
  templateUrl: './active-task.component.html',
  styleUrls: ['./active-task.component.css']
})
export class ActiveTaskComponent implements OnInit {
  activeTask: Task;

  constructor(private padService: PadService, private router: Router) { }

  ngOnInit(): void {
    this.activeTask = this.padService.getActiveTask();
  }

  onOpenPad() {
    const activePageIndex = this.padService.getActivePageIndex();
    this.router.navigate([activePageIndex]);
  }
}

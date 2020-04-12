import { Component, OnInit, OnDestroy } from '@angular/core';
import { Subscription } from 'rxjs';
import { ActivatedRoute, Params, Router } from '@angular/router';

import { Task } from 'src/app/shared/task.model';
import { PadService } from 'src/app/shared/pad.service';
import { PageService } from 'src/app/shared/page.service';

@Component({
  selector: 'app-task-detail',
  templateUrl: './task-detail.component.html',
  styleUrls: ['./task-detail.component.css']
})
export class TaskDetailComponent implements OnInit, OnDestroy {
  task: Task;
  isTaskActive: boolean;
  paramsSubscription: Subscription;

  constructor(private padService: PadService,
              private pageService: PageService,
              private route: ActivatedRoute,
              private router: Router) { }

  ngOnInit(): void {
    this.paramsSubscription = this.route.params
    .subscribe(
      (params: Params) => {
        const pageIndex = this.pageService.openedPageIndex;
        const taskIndexOnPage = +params['idtask'];
        this.pageService.selectedTaskIndexOnPage = taskIndexOnPage;
        this.isTaskActive = this.checkTaskActive(pageIndex, taskIndexOnPage);
        this.task = this.padService.getTaskFromPage(pageIndex, taskIndexOnPage);
      }
    );    
  }

  checkTaskActive(pageIndex: number, taskIndexOnPage: number): boolean {
    const isActivePage = this.padService.getActivePageIndex();
    const activeTaskIndexOnPage = this.padService.getActiveTaskIndexOnPage();

    return isActivePage == pageIndex && activeTaskIndexOnPage == taskIndexOnPage;
  }

  onEdit(): void {
    this.router.navigate(['edit'], {relativeTo: this.route});
  }

  ngOnDestroy() {
    this.paramsSubscription.unsubscribe();
    this.pageService.clearSelectedTask();
  }
}

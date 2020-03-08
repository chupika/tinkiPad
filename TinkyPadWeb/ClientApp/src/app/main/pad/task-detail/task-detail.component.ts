import { Component, OnInit, OnDestroy } from '@angular/core';
import { Task } from 'src/app/shared/task.model';
import { Subscription } from 'rxjs';
import { ActivatedRoute, Params } from '@angular/router';
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
              private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.paramsSubscription = this.route.params
    .subscribe(
      (params: Params) => {
        const pageIndex = this.pageService.pageIndex;
        const taskIndexOnPage = +params['idtask'];
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

  ngOnDestroy() {
    this.paramsSubscription.unsubscribe();
  }
}

import { Component, OnInit } from '@angular/core';
import { Location } from '@angular/common';
import { ActivatedRoute, Params } from '@angular/router';

import { PadService } from 'src/app/shared/pad.service';
import { FormGroup, Validators, FormControl } from '@angular/forms';
import { PageService } from 'src/app/shared/page.service';

@Component({
  selector: 'app-task-editor',
  templateUrl: './task-editor.component.html',
  styleUrls: ['./task-editor.component.css']
})
export class TaskEditorComponent implements OnInit {
  taskIndexOnPage: number;
  pageIndex: number;
  editMode = false;
  taskForm: FormGroup;

  constructor(private route: ActivatedRoute,
              private location: Location,
              private padService: PadService,
              private pageService: PageService) { }

  ngOnInit(): void {
    this.route.params.subscribe(
      (params: Params) => {
        this.taskIndexOnPage = +params['idtask'];
        this.pageIndex = this.pageService.pageIndex;
        this.editMode = params['idtask'] != null;
        this.initForm();       
      }
    );
  }

  initForm() {
    let taskName = '';
    let taskDescription = '';

    if (this.editMode) {
      const task = this.padService.getTaskFromPage(this.pageIndex, this.taskIndexOnPage);
      taskName = task.name;
      taskDescription = task.description;
    }

    this.taskForm = new FormGroup({
      'name': new FormControl(taskName, Validators.required),
      'description': new FormControl(taskDescription)
    });
  }

  onSubmit() {
    if (this.editMode) {
      this.padService.updateTask(this.pageIndex, this.taskIndexOnPage, this.taskForm.value);
    } else {
      this.padService.addTask(this.taskForm.value);
    }

    this.onCancel();
  }

  onCancel() {
    this.location.back();
  }
}

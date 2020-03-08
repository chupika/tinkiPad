import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { TaskPlaceholderComponent } from './main/pad/task-placeholder/task-placeholder.component';
import { TaskEditorComponent } from './main/pad/task-editor/task-editor.component';
import { TaskDetailComponent } from './main/pad/task-detail/task-detail.component';
import { ActiveTaskComponent } from './active-task/active-task.component';
import { PadComponent } from './main/pad/pad.component';

const appRoutes: Routes = [
  { path: '', redirectTo: '/active-task', pathMatch: 'full' },
  { path: 'active-task', component: ActiveTaskComponent },
  { path: ':idpage', component: PadComponent, children: [
    { path: '', component: TaskPlaceholderComponent },
    { path: ':idtask', component: TaskDetailComponent },
    { path: ':idtask/edit', component: TaskEditorComponent },
    { path: 'new', component: TaskEditorComponent }
  ] }
];

@NgModule({
  imports: [
    RouterModule.forRoot(appRoutes)
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }

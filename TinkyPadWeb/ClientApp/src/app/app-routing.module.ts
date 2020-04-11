import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { TaskPlaceholderComponent } from './pad/task-placeholder/task-placeholder.component';
import { TaskEditorComponent } from './pad/task-editor/task-editor.component';
import { TaskDetailComponent } from './pad/task-detail/task-detail.component';
import { ActiveTaskComponent } from './active-task/active-task.component';
import { PadComponent } from './pad/pad.component';
import { PageNotFoundComponent } from './shared/page-not-found/page-not-found.component';

const appRoutes: Routes = [
  { path: '', redirectTo: '/active-task', pathMatch: 'full' },
  { path: 'active-task', component: ActiveTaskComponent },
  { path: 'page-not-found', component: PageNotFoundComponent },
  { path: 'new', component: TaskEditorComponent },
  { path: ':idpage', component: PadComponent, children: [
    { path: '', component: TaskPlaceholderComponent },
    { path: ':idtask', component: TaskDetailComponent },
    { path: ':idtask/edit', component: TaskEditorComponent }
  ] },
  { path: '**', redirectTo: 'page-not-found' }
];

@NgModule({
  imports: [
    RouterModule.forRoot(appRoutes)
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }

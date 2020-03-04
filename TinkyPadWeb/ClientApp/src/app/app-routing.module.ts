import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { MainComponent } from './main/main.component';
import { TaskPlaceholderComponent } from './main/pad/task-placeholder/task-placeholder.component';
import { TaskEditorComponent } from './main/pad/task-editor/task-editor.component';
import { TaskDetailComponent } from './main/pad/task-detail/task-detail.component';

const appRoutes: Routes = [
  { path: '', redirectTo: '/active-task', pathMatch: 'full' },
  { path: 'main', component: MainComponent, children: [
    { path: 'new', component: TaskEditorComponent },
    { path: ':idpage', component: TaskPlaceholderComponent },
    { path: ':idpage/:idtask', component: TaskDetailComponent },
    { path: ':idpage/:idtask/edit', component: TaskEditorComponent }
  ] }
];

@NgModule({
  imports: [
    RouterModule.forRoot(appRoutes)
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
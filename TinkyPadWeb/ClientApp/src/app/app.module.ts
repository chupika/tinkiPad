import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { HeaderComponent } from './main/header/header.component';
import { ActiveTaskComponent } from './active-task/active-task.component';
import { PadComponent } from './main/pad/pad.component';
import { PageComponent } from './main/pad/page/page.component';
import { TaskDetailComponent } from './main/pad/task-detail/task-detail.component';
import { TaskEditorComponent } from './main/pad/task-editor/task-editor.component';
import { TaskItemComponent } from './main/pad/page/task-item/task-item.component';
import { PanelComponent } from './main/panel/panel.component';
import { MainComponent } from './main/main.component';

@NgModule({
    imports: [
        BrowserModule,
        FormsModule],
    declarations: [
        AppComponent,
        PageComponent,
        PadComponent,
        ActiveTaskComponent,
        HeaderComponent,
        TaskDetailComponent,
        TaskEditorComponent,
        TaskItemComponent,
        PanelComponent,
        MainComponent
    ],
    providers: [],
    bootstrap: [AppComponent]
})
export class AppModule { }
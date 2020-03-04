import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { AppComponent } from './app.component';
import { HeaderComponent } from './header/header.component';
import { ActiveTaskComponent } from './active-task/active-task.component';
import { PadComponent } from './pad/pad.component';
import { PageComponent } from './pad/page/page.component';
import { TaskDetailComponent } from './pad/task-detail/task-detail.component';
import { TaskEditorComponent } from './pad/task-editor/task-editor.component';
import { TaskItemComponent } from './pad/page/task-item/task-item.component';;
import { PanelComponent } from './panel/panel.component'

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
        TaskItemComponent
,
        PanelComponent
    ],
    providers: [],
    bootstrap: [AppComponent]
})
export class AppModule { }
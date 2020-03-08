import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './main/header/header.component';
import { ActiveTaskComponent } from './active-task/active-task.component';
import { PadComponent } from './main/pad/pad.component';
import { TaskDetailComponent } from './main/pad/task-detail/task-detail.component';
import { TaskEditorComponent } from './main/pad/task-editor/task-editor.component';
import { PanelComponent } from './main/panel/panel.component';
import { TaskPlaceholderComponent } from './main/pad/task-placeholder/task-placeholder.component';
import { PadService } from './shared/pad.service';
import { PageService } from './shared/page.service';
import { PadProviderService } from './shared/pad-provider.service';
import { PadProviderServiceMock } from './shared/pad-provider.service.mock';

@NgModule({
    imports: [
        RouterModule,
        BrowserModule,
        FormsModule,
        ReactiveFormsModule,
        AppRoutingModule],
    declarations: [
        AppComponent,
        PadComponent,
        ActiveTaskComponent,
        HeaderComponent,
        TaskDetailComponent,
        TaskEditorComponent,
        PanelComponent,
        TaskPlaceholderComponent
    ],
    providers: [
        PadService,
        PageService,
        PadProviderService,
        PadProviderServiceMock],
    bootstrap: [AppComponent]
})
export class AppModule { }